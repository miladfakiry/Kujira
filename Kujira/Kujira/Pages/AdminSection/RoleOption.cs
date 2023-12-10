namespace Kujira.Gui.Pages.AdminSection;

public class RoleOption
{
    public RoleOption(Guid id, string? name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string? Name { get; }

    public override string? ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        return obj is RoleOption other && Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}