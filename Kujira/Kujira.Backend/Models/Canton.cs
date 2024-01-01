using Kujira.Backend.Shared;

namespace Kujira.Backend.Models;

public class Canton : DbItem
{
    public Canton(Guid id, string name, Country country) : base(id)
    {
        Id = id;
        Name = name;
        Country = country;
        CountryId = country.Id;
    }

    public Canton(Guid id, string name, Guid countryId) : base(id)
    {
        Id = id;
        Name = name;
        CountryId = countryId;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public Guid CountryId { get; set; }
}