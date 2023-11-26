using Kujira.Backend.Offer.Domain;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Persistence;

namespace Kujira.Backend.Offer.Persistence;

public class OfferRepository : RepositoryBase<Domain.Offer>, IOfferRepository
{
    public OfferRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}