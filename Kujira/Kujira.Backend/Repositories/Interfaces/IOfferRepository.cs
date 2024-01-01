using Kujira.Backend.Models;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories.Interfaces;

public interface IOfferRepository : IRepositoryBase<Offer>
{
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<Offer> GetByIdAsync(Guid id);
    Task<IEnumerable<Offer>> GetOffersByUserIdAsync(Guid userId);
    Task AddAsync(Offer offer);
    Task UpdateAsync(Offer offer);
    Task DeleteAsync(Offer offer);
}