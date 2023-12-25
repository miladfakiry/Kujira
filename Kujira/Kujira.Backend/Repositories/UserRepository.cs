using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users
                         .Include(u => u.PersonalInformation)
                         .ToList();
    }

    public User? Get(Guid id)
    {
        return _dbContext.Users
                         .Include(u => u.PersonalInformation)
                         .FirstOrDefault(u => u.Id == id);
    }
}