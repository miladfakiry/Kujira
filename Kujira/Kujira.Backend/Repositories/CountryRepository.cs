using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<Country> GetAll()
    {
        return DbContext.Countries.ToList();
    }
}