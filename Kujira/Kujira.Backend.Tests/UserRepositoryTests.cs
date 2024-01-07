using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Moq;

namespace Kujira.Backend.Tests;

[TestFixture]
public class UserRepositoryTests
{
    private Mock<IUserRepository> _userRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    [Test]
    public void Create_WhenCalled_CreatesNewUser()
    {
        // Arrange
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Test",

        };

        // Act
        _userRepositoryMock.Object.Create(newUser);

        // Assert
        _userRepositoryMock.Verify(repo => repo.Create(It.Is<User>(u =>
                u.Id == newUser.Id &&
                u.FirstName == newUser.FirstName &&
                u.LastName == newUser.LastName
        )), Times.Once);
    }

    [Test]
    public void GetAll_WhenCalled_ReturnsAllUsers()
    {
        var users = new List<User>
        {
            new()
            {
                Id = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid()
            }
        };

        _userRepositoryMock.Setup(r => r.GetAll()).Returns(users);

        var result = _userRepositoryMock.Object.GetAll();

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task GetByIdAsync_WhenCalledWithValidId_ReturnsUser()
    {
        var userId = Guid.NewGuid();
        var user = new User
        {
            Id = userId
        };

        _userRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

        var result = await _userRepositoryMock.Object.GetByIdAsync(userId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(userId));
    }

    [Test]
    public void UpdateAsync_WhenCalled_InvokesUpdateOnRepository()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "TestName"
        };

        // Act
        _userRepositoryMock.Object.Update(user);

        // Assert
        _userRepositoryMock.Verify(repo => repo.Update(It.Is<User>(u =>
                u.Id == user.Id && u.FirstName == user.FirstName
        )), Times.Once);
    }

    [Test]
    public void DeleteAsync_WhenCalled_InvokesDeleteOnRepository()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var userId = Guid.NewGuid();

        // Act
        userRepositoryMock.Object.Delete(userId);

        // Assert
        userRepositoryMock.Verify(repo => repo.Delete(userId), Times.Once);
    }

}