using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class ServiceRequestRepository : IServiceRequestRepository
{
    private readonly KujiraContext _context;

    public ServiceRequestRepository(KujiraContext context)
    {
        _context = context;
    }

    public async Task<ServiceRequest> AddAsync(ServiceRequest serviceRequest)
    {
        _context.ServiceRequests.Add(serviceRequest);
        await _context.SaveChangesAsync();
        return serviceRequest;
    }

    public async Task<IEnumerable<ServiceRequest>> GetServiceRequestsByUserIdAsync(Guid userId)
    {
        return await _context.ServiceRequests
                             .Where(sr => sr.ToUserId == userId || sr.FromUserId == userId)
                             .ToListAsync();
    }

    public async Task<ServiceRequest> GetByIdAsync(Guid requestId)
    {
        return await _context.ServiceRequests.FindAsync(requestId);
    }

    public async Task<IEnumerable<ServiceRequest>> GetServiceRequestsByOfferIdAsync(Guid offerId)
    {
        return await _context.ServiceRequests
                             .Where(sr => sr.OfferId == offerId)
                             .ToListAsync();
    }

    public async Task UpdateAsync(ServiceRequest serviceRequest)
    {
        _context.ServiceRequests.Update(serviceRequest);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckIfRequestExists(Guid userId, Guid offerId)
    {
        return await _context.ServiceRequests.AnyAsync(sr => sr.FromUserId == userId && sr.OfferId == offerId);
    }
}