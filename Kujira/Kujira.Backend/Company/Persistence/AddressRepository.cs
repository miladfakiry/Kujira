using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Company.Persistence;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}