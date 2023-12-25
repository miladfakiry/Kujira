using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Repositories;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}