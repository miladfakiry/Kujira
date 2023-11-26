using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public class PersonalInformation : DbItem
{
    public PersonalInformation(Guid id, DateTime dateOfBirth, User user) : base(id)
    {
        Id = id;
        DateOfBirth = dateOfBirth;
        User = user;
        UserId = user.Id;
    }

    public PersonalInformation(Guid id, DateTime dateOfBirth, Guid userId) : base(id)
    {
        Id = id;
        DateOfBirth = dateOfBirth;
        UserId = userId;
        
    }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}