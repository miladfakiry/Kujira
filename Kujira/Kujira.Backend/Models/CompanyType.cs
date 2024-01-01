using Kujira.Backend.Shared;

namespace Kujira.Backend.Models;

public class CompanyType : DbItem
{
    public CompanyType(Guid id, string type) : base(id)
    {
        Id = id;
        Type = type;
    }
    public Guid Id { get; set; }
    public string Type { get; set; }
}