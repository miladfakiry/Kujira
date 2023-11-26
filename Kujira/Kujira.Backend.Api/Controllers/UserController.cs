using AutoMapper;
using Kujira.Backend.Api.DTOs;
using Kujira.Backend.User.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPersonalInformationRepository _personalInformationRepository;
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository, IPersonalInformationRepository personalInformationRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _personalInformationRepository = personalInformationRepository ?? throw new ArgumentNullException(nameof(personalInformationRepository));
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

        // Aktualisieren der PersonalInformation
        personalInfo.PhoneNumber = userDto.PhoneNumber;
        personalInfo.DateOfBirth = userDto.DateOfBirth;
        //_personalInformationRepository.Update(personalInfo);

        // Mapping und Aktualisieren des User-Objekts
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