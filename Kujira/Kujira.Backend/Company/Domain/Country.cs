using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Company.Domain;

public class Country : DbItem
{
    public Country(Guid id, string name) : base(id)
    {
        Id = id;
        Name = name;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
}