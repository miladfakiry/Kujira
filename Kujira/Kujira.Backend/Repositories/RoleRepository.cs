using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Role> GetAll()
    {
        return _dbContext.Roles.ToList();
    }
}