using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public IEnumerable<Role> GetAll()
    {
        return DbContext.Roles.ToList();
    }
}