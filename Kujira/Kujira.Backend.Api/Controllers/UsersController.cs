using AutoMapper;
using Kujira.Backend.Api.DTOs;
using Kujira.Backend.User.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
        Console.WriteLine("GetUsers wurde aufgerufen!");
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
        var user = _mapper.Map<User.Domain.User>(userDto);
        _userRepository.Create(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, _mapper.Map<UserDto>(user));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UserDto userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest();
        }

        var user = _mapper.Map<User.Domain.User>(userDto);
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