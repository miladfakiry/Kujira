using Kujira.Backend.Enums;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
public class CompanyRepositoryTests
{
    private Mock<ICompanyRepository> _companyRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
    }

    private Country CreateTestCountry()
    {
        return new Country(Guid.NewGuid(), "Test Country");
    }

    private Canton CreateTestCanton()
    {
        var country = CreateTestCountry();
        return new Canton(Guid.NewGuid(), "Test Canton", country);
    }

    private Zip CreateTestZip()
    {
        var canton = CreateTestCanton();
        return new Zip(Guid.NewGuid(), "12345", "Test City", canton);
    }

    private Address CreateTestAddress()
    {
        var zip = CreateTestZip();
        return new Address(Guid.NewGuid(), "Test Street", "123", zip);
    }

    private CompanyType CreateTestCompanyType()
    {
        return new CompanyType(Guid.NewGuid(), "Test Company Type");
    }

    private Company CreateTestCompany()
    {
        var address = CreateTestAddress();
        var companyType = CreateTestCompanyType();
        return new Company(Guid.NewGuid(), "Test Company", "test@example.com", "1234567890", "https://test.com", address, companyType);
    }

    [Test]
    public void GetAll_WhenCalled_ReturnsAllCompanies()
    {
        var companies = new List<Company> { CreateTestCompany(), CreateTestCompany() };
        _companyRepositoryMock.Setup(repo => repo.GetAll()).Returns(companies);

        var result = _companyRepositoryMock.Object.GetAll();

        Assert.That(result, Is.EquivalentTo(companies));
        _companyRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Test]
    public void Get_WhenCalledWithId_ReturnsCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Setup(repo => repo.Get(company.Id)).Returns(company);

        var result = _companyRepositoryMock.Object.Get(company.Id);

        Assert.That(result, Is.EqualTo(company));
        _companyRepositoryMock.Verify(repo => repo.Get(company.Id), Times.Once);
    }

    [Test]
    public void Create_WhenCalledWithCompany_AddsCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Object.Create(company);

        _companyRepositoryMock.Verify(repo => repo.Create(It.Is<Company>(c => c.Id == company.Id)), Times.Once);
    }

    [Test]
    public void Update_WhenCalledWithCompany_UpdatesCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Object.Update(company);

        _companyRepositoryMock.Verify(repo => repo.Update(It.Is<Company>(c => c.Id == company.Id)), Times.Once);
    }

    [Test]
    public void Delete_WhenCalledWithId_DeletesCompany()
    {
        var companyId = Guid.NewGuid();
        _companyRepositoryMock.Object.Delete(companyId);

        _companyRepositoryMock.Verify(repo => repo.Delete(companyId), Times.Once);
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
        var serviceRequest = new ServiceRequest
        {
            RequestId = Guid.NewGuid(),
            OfferId = Guid.NewGuid(),
            FromUserId = Guid.NewGuid(),
            ToUserId = Guid.NewGuid(),
            Message = "Test Message",
            FromUserEMail = "test@example.com",
            RequestStatus = RequestStatus.Pending,
            CreatedAt = DateTime.UtcNow,
        };

        _serviceRequestRepositoryMock.Setup(r => r.AddAsync(It.IsAny<ServiceRequest>())).ReturnsAsync(serviceRequest);

        var result = await _serviceRequestRepositoryMock.Object.AddAsync(serviceRequest);

        Assert.Multiple(() =>
        {
            Assert.That(result.RequestId, Is.EqualTo(serviceRequest.RequestId));
            Assert.That(result.OfferId, Is.EqualTo(serviceRequest.OfferId));
            Assert.That(result.FromUserId, Is.EqualTo(serviceRequest.FromUserId));
        });
    }

    [Test]
    public async Task GetByIdAsync_WhenCalledWithValidId_ReturnsServiceRequest()
    {
        var requestId = Guid.NewGuid();
        var serviceRequest = new ServiceRequest
        {
            RequestId = requestId,
            OfferId = Guid.NewGuid(),
            FromUserId = Guid.NewGuid(),
            ToUserId = Guid.NewGuid(),
            Message = "Test Message",
            FromUserEMail = "test@example.com",
            RequestStatus = RequestStatus.Pending,
            CreatedAt = DateTime.UtcNow,
        };

        _serviceRequestRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(serviceRequest);

        var result = await _serviceRequestRepositoryMock.Object.GetByIdAsync(requestId);

        Assert.Multiple(() =>
        {
            Assert.That(result.RequestId, Is.EqualTo(requestId));
            Assert.That(result.OfferId, Is.EqualTo(serviceRequest.OfferId));
            Assert.That(result.FromUserId, Is.EqualTo(serviceRequest.FromUserId));
        });
    }

    [Test]
    public async Task UpdateAsync_WhenCalled_InvokesUpdateOnRepository()
    {
        // Arrange
        var serviceRequestId = Guid.NewGuid();
        var serviceRequest = new ServiceRequest
        {
            RequestId = serviceRequestId,
            OfferId = Guid.NewGuid(),
            FromUserId = Guid.NewGuid(),
            ToUserId = Guid.NewGuid(),
            Message = "Test Message",
            FromUserEMail = "test@example.com",
            RequestStatus = RequestStatus.Pending,
            CreatedAt = DateTime.UtcNow,
        };

        // Act
        await _serviceRequestRepositoryMock.Object.UpdateAsync(serviceRequest);

        // Assert
        _serviceRequestRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<ServiceRequest>(sr =>
                sr.RequestId == serviceRequest.RequestId &&
                sr.OfferId == serviceRequest.OfferId &&
                sr.FromUserId == serviceRequest.FromUserId &&
                sr.ToUserId == serviceRequest.ToUserId &&
                sr.Message == serviceRequest.Message &&
                sr.FromUserEMail == serviceRequest.FromUserEMail &&
                sr.RequestStatus == serviceRequest.RequestStatus &&
                sr.CreatedAt == serviceRequest.CreatedAt
        )), Times.Once);
    }

    [Test]
    public async Task GetServiceRequestsByUserIdAsync_WhenCalledWithValidId_ReturnsServiceRequests()
    {
        var userId = Guid.NewGuid();
        var serviceRequests = new List<ServiceRequest>
        {
            new ServiceRequest { RequestId = Guid.NewGuid(), ToUserId = userId },
            new ServiceRequest { RequestId = Guid.NewGuid(), ToUserId = userId }
        };

        _serviceRequestRepositoryMock.Setup(r => r.GetServiceRequestsByUserIdAsync(userId))
                                     .ReturnsAsync(serviceRequests);

        var result = await _serviceRequestRepositoryMock.Object.GetServiceRequestsByUserIdAsync(userId);

        Assert.That(result, Is.EqualTo(serviceRequests));
    }
}