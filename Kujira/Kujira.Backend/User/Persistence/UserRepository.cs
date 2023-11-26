using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.User.Persistence;

public class UserRepository : RepositoryBase<Domain.User>, IUserRepository
{
    public UserRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Domain.User> GetAll()
    {
        return _dbContext.Users
                         .Include(u => u.PersonalInformation)
                         .ToList();
    }

    public Domain.User? Get(Guid id)
    {
        return _dbContext.Users
                         .Include(u => u.PersonalInformation)
                         .FirstOrDefault(u => u.Id == id);
    }

}