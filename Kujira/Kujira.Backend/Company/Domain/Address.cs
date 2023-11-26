using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Company.Domain;

public class Address : DbItem
{

    public Address(Guid id, string street, string streetNumber, Zip zip) : base(id)
    {
        Id = id;
        Street = street;
        StreetNumber = streetNumber;
        Zip = zip;
        ZipId = Zip.Id;
    }

    public Address(Guid id, string street, string streetNumber, Guid zipId) : base(id)
    {
        Id = id;
        Street = street;
        StreetNumber = streetNumber;
        ZipId = zipId;
    }

    public Guid Id { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public Zip Zip { get; set; }
    public Guid ZipId { get; set; }
}