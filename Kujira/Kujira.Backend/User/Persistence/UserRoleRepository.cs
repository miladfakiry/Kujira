using Kujira.Backend.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.User.Persistence;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly KujiraContext _dbContext;

    public UserRoleRepository(KujiraContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(UserRole userRole)
    {
        _dbContext.UserRoles.Add(userRole);
        _dbContext.SaveChanges();
    }

    public void Delete(Guid userId, Guid roleId)
    {
        var userRole = _dbContext.UserRoles.Find(userId, roleId);
        if (userRole != null)
        {
            _dbContext.UserRoles.Remove(userRole);
            _dbContext.SaveChanges();
        }
    }

    public UserRole Get(Guid userId, Guid roleId)
    {
        return _dbContext.UserRoles
                         .Where(ur => ur.UserId == userId && ur.RoleId == roleId)
                         .Include(ur => ur.User)
                         .Include(ur => ur.Role)
                         .FirstOrDefault();
    }

    public IEnumerable<UserRole> GetRolesByUserId(Guid userId)
    {
        return _dbContext.UserRoles
                         .Where(ur => ur.UserId == userId)
                         .Include(ur => ur.Role)
                         .ToList();
    }
}