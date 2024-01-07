using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILoginRepository _loginRepository;
    private readonly IMapper _mapper;
    private readonly IPersonalInformationRepository _personalInformationRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public UserController(IUserRepository userRepository, IPersonalInformationRepository personalInformationRepository, ILoginRepository loginRepository, IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _personalInformationRepository = personalInformationRepository ?? throw new ArgumentNullException(nameof(personalInformationRepository));
        _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        _userRoleRepository = userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
        var users = _userRepository.GetAll();
        var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(userDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> GetUser(Guid id)
    {
        var user = _userRepository.Get(id);
        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }

    [HttpPost]
    public ActionResult<UserDto> CreateUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.PersonalInformation = _mapper.Map<PersonalInformation>(userDto);
        _userRepository.Create(user);

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        var login = new Login(Guid.NewGuid(), userDto.Email, hashedPassword)
        {
            UserId = user.Id
        };
        _loginRepository.Create(login);

        var role = _roleRepository.Get(userDto.RoleId);
        if (role == null)
        {
            return NotFound($"Rolle mit ID {userDto.RoleId} nicht gefunden.");
        }

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = role.Id
        };
        _userRoleRepository.Create(userRole);

        return CreatedAtAction(nameof(GetUser), new
        {
            id = user.Id
        }, _mapper.Map<UserDto>(user));
    }


    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UserDto userDto)
    {
        var user = _userRepository.Get(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var personalInfo = user.PersonalInformation;
        if (personalInfo == null)
        {
            throw new KeyNotFoundException("PersonalInformation not found");
        }


        personalInfo.PhoneNumber = userDto.PhoneNumber;
        personalInfo.DateOfBirth = userDto.DateOfBirth;


        _mapper.Map(userDto, user);
        _userRepository.Update(user);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _userRepository.Get(id);
        if (user == null)
        {
            return NotFound();
        }

        _userRepository.Delete(id);
        return NoContent();
    }
}

