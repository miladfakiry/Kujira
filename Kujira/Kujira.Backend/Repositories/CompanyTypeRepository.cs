using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class CompanyTypeRepository : RepositoryBase<CompanyType>, ICompanyTypeRepository
{
    public CompanyTypeRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<CompanyType> GetAll()
    {
        return DbContext.CompanyTypes.ToList();
    }

    public CompanyType? Get(Guid id)
    {
        return DbContext.CompanyTypes.Find(id);
    }

    public void Create(CompanyType companyType)
    {
        DbContext.CompanyTypes.Add(companyType);
        DbContext.SaveChanges();
    }

    public void Update(CompanyType companyType)
    {
        DbContext.Entry(companyType).State = EntityState.Modified;
        DbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var companyType = Get(id);
        if (companyType != null)
        {
            DbContext.CompanyTypes.Remove(companyType);
            DbContext.SaveChanges();
        }
    }

}