using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;

namespace Kujira.Backend.User.Persistence;

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