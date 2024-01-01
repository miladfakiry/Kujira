using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories;

public class CantonRepository : RepositoryBase<Canton>, ICantonRepository
{
    public CantonRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }
}