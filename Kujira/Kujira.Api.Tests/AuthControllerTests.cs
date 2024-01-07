using Kujira.Api.Controllers;
using Kujira.Api.DTOs;
using Kujira.Api.Settings;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace Kujira.Api.Tests;

public class AuthControllerTests
{
    private AuthController _controller;
    private Mock<IOptions<JwtSettings>> _mockJwtSettings;
    private Mock<ILoginRepository> _mockLoginRepository;
    private Mock<IUserRoleRepository> _mockUserRoleRepository;

    [SetUp]
    public void Setup()
    {
        _mockJwtSettings = new Mock<IOptions<JwtSettings>>();
        _mockLoginRepository = new Mock<ILoginRepository>();
        _mockUserRoleRepository = new Mock<IUserRoleRepository>();
        var jwtSettings = new JwtSettings
        {
            Key = "MySuperSecretKeyForJwtAuthentication12345!",
            Issuer = "KujiraApi",
            Audience = "KujiraWebClients",
            ExpirationInMinutes = 30
        };


        _mockJwtSettings.Setup(j => j.Value).Returns(jwtSettings);
        _controller = new AuthController(_mockJwtSettings.Object, _mockLoginRepository.Object, _mockUserRoleRepository.Object);
    }

    [Test]
    public void Login_WithValidCredentials_ReturnsOkAndToken()
    {
        // Arrange
        var loginDto = new LoginDto
        {
            Email = "test@example.com",
            Password = "password"
        };
        var user = new User
        {
            FirstName = "TestFirstName",
            LastName = "TestLastName"
        };
        var login = new Login(Guid.NewGuid(), "test@example.com", BCrypt.Net.BCrypt.HashPassword("password"))
        {
            User = user
        };
        var roleId = Guid.NewGuid();
        var userRoles = new List<UserRole>
        {
            new()
            {
                UserId = login.UserId,
                RoleId = roleId,
                Role = new Role(roleId, "RoleName")
            }
        };

        _mockLoginRepository.Setup(r => r.GetLoginByEmail(loginDto.Email)).Returns(login);
        _mockUserRoleRepository.Setup(r => r.GetRolesByUserId(login.UserId)).Returns(userRoles);

        // Act
        var result = _controller.Login(loginDto);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        // Zusätzliche Überprüfungen für das Token, falls erforderlich...
    }


    [Test]
    public void Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var loginDto = new LoginDto
        {
            Email = "test@example.com",
            Password = "wrongpassword"
        };
        var login = new Login(Guid.NewGuid(), "test@example.com", BCrypt.Net.BCrypt.HashPassword("password"));

        _mockLoginRepository.Setup(r => r.GetLoginByEmail(loginDto.Email)).Returns(login);

        // Act
        var result = _controller.Login(loginDto);

        // Assert
        Assert.IsInstanceOf<UnauthorizedResult>(result);
    }

    //Negativ Test
    [Test]
    public void ValidateToken_InvalidToken_ReturnsBadRequest()
    {
        // Arrange
        var invalidToken = "invalid.token.value";

        // Act
        var result = _controller.ValidateToken(invalidToken);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }
}