using Kujira.Backend.Shared;

namespace Kujira.Backend.Models;

public class Role : DbItem
{
    public Role(Guid id, string name) : base(id)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
}