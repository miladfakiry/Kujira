using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;

namespace Kujira.Backend.User.Persistence;

public class PersonalInformationRepository : RepositoryBase<PersonalInformation>, IPersonalInformationRepository
{
    public PersonalInformationRepository(KujiraContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}