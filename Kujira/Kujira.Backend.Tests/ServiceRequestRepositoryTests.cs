using Kujira.Backend.Enums;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Moq;

namespace Kujira.Backend.Tests;

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