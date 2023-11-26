using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Company.Persistence;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Country> GetAll()
    {
        return _dbContext.Countries.ToList();
    }
}