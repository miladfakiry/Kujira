using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Offer.Domain;

public interface IOfferRepository : IRepositoryBase<Offer>
{
    Task<IEnumerable<Offer>> GetAllAsync();
    Task<Offer> GetByIdAsync(Guid id);
    Task<IEnumerable<Offer>> GetOffersByUserIdAsync(Guid userId);
    Task AddAsync(Offer offer);
    Task UpdateAsync(Offer offer);
    Task DeleteAsync(Offer offer);
}