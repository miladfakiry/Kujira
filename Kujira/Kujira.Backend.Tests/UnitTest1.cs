using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Kujira.Backend.Tests;

[TestFixture]
public class UserRepositoryTests
{
    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    private Mock<IUserRepository> _userRepositoryMock;

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
        var userRepositoryMock = new Mock<IUserRepository>();
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Maximilian"
        };

        // Act
        userRepositoryMock.Object.Update(user);

        // Assert
        userRepositoryMock.Verify(repo => repo.Update(user), Times.Once);
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

public static class DbSetMocking
{
    public static DbSet<T> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
    {
        var elementsAsQueryable = elements.AsQueryable();
        var dbSetMock = new Mock<DbSet<T>>();

        dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

        return dbSetMock.Object;
    }
}

[TestFixture]
public class ServiceRequestRepositoryTests
{
    [SetUp]
    public void Setup()
    {
        _serviceRequestRepositoryMock = new Mock<IServiceRequestRepository>();
    }

    private Mock<IServiceRequestRepository> _serviceRequestRepositoryMock;

    [Test]
    public async Task AddAsync_WhenCalled_AddsServiceRequest()
    {
        var serviceRequest = new ServiceRequest();
        _serviceRequestRepositoryMock.Setup(r => r.AddAsync(It.IsAny<ServiceRequest>())).ReturnsAsync(serviceRequest);

        var result = await _serviceRequestRepositoryMock.Object.AddAsync(serviceRequest);

        Assert.That(result, Is.EqualTo(serviceRequest));
    }

    [Test]
    public async Task GetByIdAsync_WhenCalledWithValidId_ReturnsServiceRequest()
    {
        var requestId = Guid.NewGuid();
        var serviceRequest = new ServiceRequest
        {
            RequestId = requestId
        };

        _serviceRequestRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(serviceRequest);

        var result = await _serviceRequestRepositoryMock.Object.GetByIdAsync(requestId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.RequestId, Is.EqualTo(requestId));
    }

    // Weitere Tests...
}