using Kujira.Backend.Models;

namespace Kujira.Backend.Repositories.Interfaces;
public interface IUserRoleRepository
{
    void Create(UserRole userRole);
    void Delete(Guid userId, Guid roleId);
    UserRole Get(Guid userId, Guid roleId);

    IEnumerable<UserRole> GetRolesByUserId(Guid userId);
}