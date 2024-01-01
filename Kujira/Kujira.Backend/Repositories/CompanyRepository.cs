using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<Company> GetAll()
    {
        return DbContext.Companies.Include(ct => ct.CompanyType).Include(c => c.Address).ThenInclude(a => a.Zip).ThenInclude(z => z.Canton).ThenInclude(can => can.Country).ToList();
    }

    public Company? Get(Guid id)
    {
        return DbContext.Companies.Include(ct => ct.CompanyType)
                         .Include(c => c.Address)
                         .ThenInclude(a => a.Zip)
                         .ThenInclude(z => z.Canton)
                         .ThenInclude(can => can.Country)
                         .FirstOrDefault(c => c.Id == id);
    }
}