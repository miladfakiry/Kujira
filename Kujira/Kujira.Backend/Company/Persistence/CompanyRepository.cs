using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Company.Persistence;

public class CompanyRepository : RepositoryBase<Domain.Company>, ICompanyRepository
{
    public CompanyRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Domain.Company> GetAll()
    {
        return _dbContext.Companies.Include(ct => ct.CompanyType)
                         .Include(c => c.Address)
                         .ThenInclude(a => a.Zip)
                         .ThenInclude(z => z.Canton)
                         .ThenInclude(can => can.Country)
                         .ToList();
    }

    public Domain.Company? Get(Guid id)
    {
        return _dbContext.Companies
                         .Include(ct => ct.CompanyType)
                         .Include(c => c.Address)
                         .ThenInclude(a => a.Zip)
                         .ThenInclude(z => z.Canton)
                         .ThenInclude(can => can.Country)
                         .FirstOrDefault(c => c.Id == id);
    }
}