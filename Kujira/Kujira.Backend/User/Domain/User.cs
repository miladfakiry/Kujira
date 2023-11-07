using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public class User : DbItem
{
    public User(Guid id, string firstName, string lastName, DateTime dateOfBirth, string eMail, string? phoneNumber, bool isInactive, DateTime createDate) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        EMail = eMail;
        PhoneNumber = phoneNumber;
        CreateDate = createDate;
        IsInactive = isInactive;
        //Company = company;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string EMail { get; set; }
    public string? PhoneNumber { get; set; }

    public bool IsInactive { get; set; }
    public DateTime CreateDate { get; set; }
    //public Company.Domain.Company Company { get; set; }
}