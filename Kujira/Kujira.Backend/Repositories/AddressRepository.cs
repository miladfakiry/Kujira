using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }
}