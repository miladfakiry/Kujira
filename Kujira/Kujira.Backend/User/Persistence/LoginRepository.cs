using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;

namespace Kujira.Backend.User.Persistence;

public class LoginRepository : RepositoryBase<Login>, ILoginRepository
{
    public LoginRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}