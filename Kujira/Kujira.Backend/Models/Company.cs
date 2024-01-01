using Kujira.Backend.Shared;

namespace Kujira.Backend.Models;

public class Company : DbItem
{
    public Company(Guid id, string name, string eMailAddress, string phoneNumber, string websiteAddress, Address? address, CompanyType? companyType) : base(id)
    {
        Id = id;
        Name = name;
        EMailAddress = eMailAddress;
        PhoneNumber = phoneNumber;
        WebsiteAddress = websiteAddress;
        Address = address;
        AddressId = address.Id;
        CompanyType = companyType;
        CompanyTypeId = companyType.Id;
    }

    public Company(Guid id, string name, string eMailAddress, string phoneNumber, string websiteAddress, Guid addressId, Guid companyTypeId) : base(id)
    {
        Id = id;
        Name = name;
        EMailAddress = eMailAddress;
        PhoneNumber = phoneNumber;
        WebsiteAddress = websiteAddress;
        AddressId = addressId;
        CompanyTypeId = companyTypeId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string EMailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string WebsiteAddress { get; set; }
    public Address? Address { get; set; }
    public Guid AddressId { get; set; }
    public CompanyType? CompanyType { get; set; }
    public Guid CompanyTypeId { get; set; }

    public ICollection<User>? Users { get; set; }
}