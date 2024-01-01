using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Kujira.Backend.Shared;

namespace Kujira.Backend.Repositories;

public class PersonalInformationRepository : RepositoryBase<PersonalInformation>, IPersonalInformationRepository
{
    public PersonalInformationRepository(KujiraContext dbContext) : base(dbContext)
    {
        DbContext = dbContext;
    }
}