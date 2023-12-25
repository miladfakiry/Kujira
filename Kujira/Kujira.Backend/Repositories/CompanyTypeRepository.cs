using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class CompanyTypeRepository : RepositoryBase<CompanyType>, ICompanyTypeRepository
{
    public CompanyTypeRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<CompanyType> GetAll()
    {
        return _dbContext.CompanyTypes.ToList();
    }

    public CompanyType? Get(Guid id)
    {
        return _dbContext.CompanyTypes.Find(id);
    }

    public void Create(CompanyType companyType)
    {
        _dbContext.CompanyTypes.Add(companyType);
        _dbContext.SaveChanges();
    }

    public void Update(CompanyType companyType)
    {
        _dbContext.Entry(companyType).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var companyType = Get(id);
        if (companyType != null)
        {
            _dbContext.CompanyTypes.Remove(companyType);
            _dbContext.SaveChanges();
        }
    }

}