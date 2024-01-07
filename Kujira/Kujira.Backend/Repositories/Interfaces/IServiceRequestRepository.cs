using Kujira.Backend.Models;

namespace Kujira.Backend.Repositories.Interfaces;

public interface IServiceRequestRepository
{
    Task<ServiceRequest> AddAsync(ServiceRequest serviceRequest);
    Task<IEnumerable<ServiceRequest>> GetServiceRequestsByUserIdAsync(Guid userId);
    Task<ServiceRequest> GetByIdAsync(Guid requestId);
    Task<IEnumerable<ServiceRequest>> GetServiceRequestsByOfferIdAsync(Guid offerId);
    Task UpdateAsync(ServiceRequest serviceRequest);
    Task<bool> CheckIfRequestExists(Guid userId, Guid offerId);
}