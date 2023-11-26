using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Company.Domain;

public interface IZipRepository : IRepositoryBase<Zip>
{
    Zip GetByCodeWithCantonAndCountry(string code);
}