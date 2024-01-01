using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }

    public new IEnumerable<User> GetAll()
    {
        return DbContext.Users
                         .Include(u => u.PersonalInformation)
                         .ToList();
    }

    public new User? Get(Guid id)
    {
        return DbContext.Users
                         .Include(u => u.PersonalInformation)
                         .FirstOrDefault(u => u.Id == id);
    }
}