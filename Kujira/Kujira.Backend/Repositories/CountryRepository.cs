using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Repositories;

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