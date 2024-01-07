using AutoMapper;
using Kujira.Api.Controllers;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Kujira.Api.Tests;

public class UserControllerTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IPersonalInformationRepository> _mockPersonalInformationRepository;
    private Mock<ILoginRepository> _mockLoginRepository;
    private Mock<IRoleRepository> _mockRoleRepository;
    private Mock<IUserRoleRepository> _mockUserRoleRepository;
    private Mock<IMapper> _mockMapper;
    private UserController _controller;
 

    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockPersonalInformationRepository = new Mock<IPersonalInformationRepository>();
        _mockLoginRepository = new Mock<ILoginRepository>();
        _mockRoleRepository = new Mock<IRoleRepository>();
        _mockUserRoleRepository = new Mock<IUserRoleRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new UserController(_mockUserRepository.Object, _mockPersonalInformationRepository.Object, 
            _mockLoginRepository.Object, _mockRoleRepository.Object, _mockUserRoleRepository.Object, _mockMapper.Object);
    }

    [Test]
    public void GetUsers_ReturnsAllUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Johnson" },
            new User { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Smith" }
        };

        var userDtos = users.Select(u => new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
        }).ToList();

        _mockUserRepository.Setup(repo => repo.GetAll()).Returns(users);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<User>>())).Returns(userDtos);

        // Act
        var result = _controller.GetUsers();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var resultValue = okResult.Value as IEnumerable<UserDto>;
        Assert.AreEqual(userDtos.Count, resultValue.Count());
    }


    [Test]
    public void GetUser_ExistingId_ReturnsUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, FirstName = "Alice", LastName = "Johnson" };
        var userDto = new UserDto
        {
            Id = userId,
            FirstName = "Alice",
            LastName = "Johnson"
        };

        _mockUserRepository.Setup(repo => repo.Get(userId)).Returns(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(user)).Returns(userDto);

        // Act
        var result = _controller.GetUser(userId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(userDto, okResult.Value);
    }

    [Test]
    public void CreateUser_ValidUser_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var userDto = new UserDto
        {
            FirstName = "New",
            LastName = "User",
            Email = "newuser@example.com",
            Password = "password123",
            RoleId = Guid.NewGuid(),
            CompanyId = Guid.NewGuid(),
            DateOfBirth = DateTime.Now.AddYears(-30)
        };
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "New",
            LastName = "User",
            PersonalInformation = new PersonalInformation(Guid.NewGuid(), userDto.DateOfBirth, Guid.NewGuid())
        };
        var role = new Role(userDto.RoleId, "TestRole");

        _mockMapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(user);
        _mockRoleRepository.Setup(repo => repo.Get(userDto.RoleId)).Returns(role);
        _mockLoginRepository.Setup(repo => repo.Create(It.IsAny<Login>())).Verifiable();
        _mockUserRepository.Setup(repo => repo.Create(user)).Verifiable();

        // Act
        var result = _controller.CreateUser(userDto);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
        _mockUserRepository.Verify(repo => repo.Create(It.IsAny<User>()), Times.Once);
        _mockLoginRepository.Verify(repo => repo.Create(It.IsAny<Login>()), Times.Once);
    }



    [Test]
    public void UpdateUser_ValidUser_ReturnsNoContentResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var userDto = new UserDto
        {
            Id = userId,
            FirstName = "Updated",
            LastName = "User",
            Email = "updateduser@example.com",
            Password = "newpassword123",
            RoleId = Guid.NewGuid(),
            CompanyId = Guid.NewGuid(),
            DateOfBirth = DateTime.Now.AddYears(-25)
        };

        var personalInfo = new PersonalInformation(Guid.NewGuid(), userDto.DateOfBirth, userId)
        {
            PhoneNumber = "123456789"
        };

        var user = new User
        {
            Id = userId,
            FirstName = "Old",
            LastName = "User",
            PersonalInformation = personalInfo
        };

        _mockUserRepository.Setup(repo => repo.Get(userId)).Returns(user);
        _mockMapper.Setup(m => m.Map<UserDto, User>(userDto, user)).Verifiable();
        _mockUserRepository.Setup(repo => repo.Update(user)).Verifiable();

        // Act
        var result = _controller.UpdateUser(userId, userDto);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
        _mockUserRepository.Verify(repo => repo.Update(It.IsAny<User>()), Times.Once);
    }

    [Test]
    public void DeleteUser_ExistingId_ReturnsNoContentResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, FirstName = "Alice", LastName = "Johnson" };

        _mockUserRepository.Setup(repo => repo.Get(userId)).Returns(user);
        _mockUserRepository.Setup(repo => repo.Delete(userId)).Verifiable();

        // Act
        var result = _controller.DeleteUser(userId);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
        _mockUserRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()), Times.Once);
    }

    // Negativ Test
    [Test]
    public void GetUser_NonExistingId_ReturnsNotFoundResult()
    {
        // Arrange
        var nonExistingUserId = Guid.NewGuid();

        _mockUserRepository.Setup(repo => repo.Get(nonExistingUserId)).Returns((User)null);

        // Act
        var result = _controller.GetUser(nonExistingUserId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

}