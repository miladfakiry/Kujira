using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class LoginRepository : RepositoryBase<Login>, ILoginRepository
{
    public LoginRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public Login GetLoginByEmail(string email)
    {
        return DbContext.Logins
                         .Include(l => l.User)
                         .FirstOrDefault(l => l.Email == email);
    }

}