using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Company.Persistence;

public class CantonRepository : RepositoryBase<Canton>, ICantonRepository
{
    public CantonRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}