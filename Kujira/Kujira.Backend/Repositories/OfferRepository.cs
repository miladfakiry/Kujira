using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class OfferRepository : RepositoryBase<Models.Offer>, IOfferRepository
{
    public OfferRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Models.Offer>> GetAllAsync()
    {
        return await _dbContext.Offers
                               .Include(o => o.User)
                               .ThenInclude(u => u.Company)
                               .ThenInclude(c => c.Address)
                               .ThenInclude(a => a.Zip)
                               .ToListAsync();
    }


    public async Task<Models.Offer> GetByIdAsync(Guid id)
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

    public async Task<IEnumerable<Models.Offer>> GetOffersByUserIdAsync(Guid userId)
    {
        return await _dbContext.Offers
                               .Where(o => o.UserId == userId)
                               .ToListAsync();
    }

    public async Task AddAsync(Models.Offer offer)
    {
        await _dbContext.Offers.AddAsync(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Models.Offer offer)
    {
        _dbContext.Offers.Update(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Models.Offer offer)
    {
        _dbContext.Offers.Remove(offer);
        await _dbContext.SaveChangesAsync();
    }
}