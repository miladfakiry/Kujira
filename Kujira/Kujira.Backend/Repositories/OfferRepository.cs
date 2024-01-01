using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
{
    public OfferRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<IEnumerable<Offer>> GetAllAsync()
    {
        return await DbContext.Offers.Include(o => o.User).ThenInclude(u => u.Company).ThenInclude(c => c.Address).ThenInclude(a => a.Zip).ToListAsync();
    }


    public async Task<Offer> GetByIdAsync(Guid id)
    {
        var offer = await DbContext.Offers.Include(o => o.User).FirstOrDefaultAsync(o => o.Id == id);

        if (offer == null)
        {
            throw new KeyNotFoundException($"Offer with ID {id} not found.");
        }

        return offer;
    }

    public async Task<IEnumerable<Offer>> GetOffersByUserIdAsync(Guid userId)
    {
        return await DbContext.Offers.Where(o => o.UserId == userId).ToListAsync();
    }

    public async Task AddAsync(Offer offer)
    {
        await DbContext.Offers.AddAsync(offer);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Offer offer)
    {
        DbContext.Offers.Update(offer);
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Offer offer)
    {
        DbContext.Offers.Remove(offer);
        await DbContext.SaveChangesAsync();
    }
}