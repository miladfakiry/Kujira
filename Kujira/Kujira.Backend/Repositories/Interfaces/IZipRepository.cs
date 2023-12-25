using Kujira.Backend.Models;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Repositories.Interfaces;

public interface IZipRepository : IRepositoryBase<Zip>
{
    Zip GetByCodeWithCantonAndCountry(string code);
    Task<Zip> GetByIdAsync(Guid id);
}