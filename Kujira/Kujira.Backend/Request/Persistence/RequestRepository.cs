using Kujira.Backend.Request.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Request.Persistence;

public class RequestRepository : RepositoryBase<Domain.Request>, IRequestRepository
{
    public RequestRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}