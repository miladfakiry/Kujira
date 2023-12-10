using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public interface IUserRoleRepository
{
    void Create(UserRole userRole);
    void Delete(Guid userId, Guid roleId);
    UserRole Get(Guid userId, Guid roleId);

    IEnumerable<UserRole> GetRolesByUserId(Guid userId);
}