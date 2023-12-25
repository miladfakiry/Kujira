using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class ZipRepository : RepositoryBase<Zip>, IZipRepository
{
    public ZipRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Zip> GetAll()
    {
        return _dbContext.Zips.Include(z => z.Canton).ThenInclude(c => c.Country).ToList();
    }

    public Zip GetByCodeWithCantonAndCountry(string code)
    {
        return _dbContext.Zips.Include(z => z.Canton)
                         .ThenInclude(c => c.Country)
                         .FirstOrDefault(z => z.Code == code);
    }

    public async Task<Zip> GetByIdAsync(Guid id)
    {
        return await _dbContext.Zips.Include(z => z.Canton)
                               .ThenInclude(c => c.Country)
                               .FirstOrDefaultAsync(z => z.Id == id);
    }
}