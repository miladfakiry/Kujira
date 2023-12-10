using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kujira.Api.DTOs;
using Kujira.Api.Settings;
using Kujira.Backend.User.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILoginRepository _loginRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly JwtSettings _jwtSettings;

    public AuthController(IOptions<JwtSettings> jwtSettings, ILoginRepository loginRepository, IUserRoleRepository userRoleRepository)
    {
        _loginRepository = loginRepository;
        _userRoleRepository = userRoleRepository;
        _jwtSettings = jwtSettings.Value;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var loginEntry = _loginRepository.GetLoginByEmail(loginDto.Email);
        if (loginEntry != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, loginEntry.Password))
        {
            var userRoles = _userRoleRepository.GetRolesByUserId(loginEntry.UserId);
            var token = GenerateJwtToken(loginEntry, userRoles);
            return Ok(new { token });
        }
        return Unauthorized();
    }

    [HttpPost("validateToken")]
    public ActionResult<UserInfo> ValidateToken([FromBody] string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Optional: Anpassen der Toleranz für die Token-Lebensdauer
            };

            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;

            var email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;
            if (email == null)
            {
                return BadRequest("Email claim not found in token");
            }

            var userInfo = new UserInfo
            {
                Email = email,
                Roles = jwtToken.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList()
            };

            return Ok(userInfo);
        }
        catch (SecurityTokenExpiredException)
        {
            return Unauthorized("Token is expired.");
        }
        catch (SecurityTokenValidationException)
        {
            return Unauthorized("Token is invalid.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while validating token: {ex.Message}");
        }
    }


    private string GenerateJwtToken(Login login, IEnumerable<UserRole> userRoles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, login.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            // Weitere benutzerspezifische Claims hinzufügen
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            claims.Add(new Claim("UserId", login.UserId.ToString()));
        }

        var token = new JwtSecurityToken(_jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}