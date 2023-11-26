using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Company.Persistence;

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
}