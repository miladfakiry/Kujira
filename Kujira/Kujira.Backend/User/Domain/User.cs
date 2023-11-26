using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public class User : DbItem
{
    public User() : base(Guid.NewGuid())
    {
        Offers = new HashSet<Offer.Domain.Offer>();
        Requests = new HashSet<Request.Domain.Request>();
    }
    public User(Guid id, string? firstName, string? lastName, bool isInactive, DateTime createDate, Company.Domain.Company? company) : base(id)
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

        Offers = new HashSet<Offer.Domain.Offer>();
        Requests = new HashSet<Request.Domain.Request>();
    }

    public User(Guid id, string? firstName, string? lastName, bool isInactive, DateTime createDate, Guid companyId) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        IsInactive = isInactive;
        CreateDate = createDate;
        CompanyId = companyId;
        Offers = new HashSet<Offer.Domain.Offer>();
        Requests = new HashSet<Request.Domain.Request>();
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsInactive { get; set; }
    public DateTime CreateDate { get; set; }

    public Company.Domain.Company? Company { get; set; }
    public Guid CompanyId { get; set; }

    public PersonalInformation? PersonalInformation { get; set; }

    public ICollection<Offer.Domain.Offer> Offers { get; set; }
    public ICollection<Request.Domain.Request> Requests { get; set; }


}