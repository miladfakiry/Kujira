using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.User.Persistence;

public class LoginRepository : RepositoryBase<Login>, ILoginRepository
{
    public LoginRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Login GetLoginByEmail(string email)
    {
        return _dbContext.Logins
                         .Include(l => l.User)
                         .FirstOrDefault(l => l.Email == email);
    }
}