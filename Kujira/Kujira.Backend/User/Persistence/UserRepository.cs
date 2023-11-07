using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;

namespace Kujira.Backend.User.Persistence;

public class UserRepository : RepositoryBase<Domain.User>, IUserRepository
{
    public UserRepository(DbContextBase<Domain.User> dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

}