using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class ZipRepository : RepositoryBase<Zip>, IZipRepository
{
    public ZipRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<Zip> GetAll()
    {
        return DbContext.Zips.Include(z => z.Canton).ThenInclude(c => c.Country).ToList();
    }

    public Zip GetByCodeWithCantonAndCountry(string code)
    {
        return DbContext.Zips.Include(z => z.Canton)
                         .ThenInclude(c => c.Country)
                         .FirstOrDefault(z => z.Code == code);
    }

    public async Task<Zip> GetByIdAsync(Guid id)
    {
        return await DbContext.Zips.Include(z => z.Canton)
                               .ThenInclude(c => c.Country)
                               .FirstOrDefaultAsync(z => z.Id == id);
    }
}