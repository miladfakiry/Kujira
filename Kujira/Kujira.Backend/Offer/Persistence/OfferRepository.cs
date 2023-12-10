using Kujira.Backend.Company.Domain;
using Kujira.Backend.Offer.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Offer.Persistence;

public class OfferRepository : RepositoryBase<Domain.Offer>, IOfferRepository
{
    public OfferRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Domain.Offer>> GetAllAsync()
    {
        return await _dbContext.Offers
                               .Include(o => o.User)
                               .ThenInclude(u => u.Company)
                               .ThenInclude(c => c.Address)
                               .ThenInclude(a => a.Zip)
                               .ToListAsync();
    }


    public async Task<Domain.Offer> GetByIdAsync(Guid id) 
    {
        var offer = await _dbContext.Offers
                                    .Include(o => o.User)
                                    .FirstOrDefaultAsync(o => o.Id == id);

        if (offer == null)
        {
            throw new KeyNotFoundException($"Offer with ID {id} not found.");
        }

        return offer;
    }

    public async Task<IEnumerable<Domain.Offer>> GetOffersByUserIdAsync(Guid userId)
    {
        return await _dbContext.Offers
                               .Where(o => o.UserId == userId)
                               .ToListAsync();
    }

    public async Task AddAsync(Domain.Offer offer)
    {
        await _dbContext.Offers.AddAsync(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Domain.Offer offer)
    {
        _dbContext.Offers.Update(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Offer offer)
    {
        _dbContext.Offers.Remove(offer);
        await _dbContext.SaveChangesAsync();
    }
}