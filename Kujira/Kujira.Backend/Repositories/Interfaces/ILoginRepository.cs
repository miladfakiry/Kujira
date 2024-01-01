using Kujira.Backend.Models;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories.Interfaces;

public interface ILoginRepository : IRepositoryBase<Login>
{
    Login GetLoginByEmail(string email);
}