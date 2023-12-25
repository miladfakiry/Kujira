using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Models;

public class User : DbItem
{
    public User() : base(Guid.NewGuid())
    {
        Offers = new HashSet<Offer>();
        Requests = new HashSet<Request>();
    }
    public User(Guid id, string? firstName, string? lastName, bool isInactive, DateTime createDate, Company? company) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        IsInactive = isInactive;
        CreateDate = createDate;
        Company = company;
        if (company != null)
        {
            CompanyId = company.Id;
        }

        Offers = new HashSet<Offer>();
        Requests = new HashSet<Request>();
    }

    public User(Guid id, string? firstName, string? lastName, bool isInactive, DateTime createDate, Guid companyId) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        IsInactive = isInactive;
        CreateDate = createDate;
        CompanyId = companyId;
        Offers = new HashSet<Offer>();
        Requests = new HashSet<Request>();
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsInactive { get; set; }
    public DateTime CreateDate { get; set; }

    public Company? Company { get; set; }
    public Guid CompanyId { get; set; }

    public PersonalInformation? PersonalInformation { get; set; }

    public ICollection<Offer> Offers { get; set; }
    public ICollection<Request> Requests { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

    public string? ProfilePicturePath { get; set; }

}