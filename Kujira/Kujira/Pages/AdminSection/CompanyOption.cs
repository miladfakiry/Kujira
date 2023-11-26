namespace Kujira.Gui.Pages.AdminSection
{
    public class CompanyOption
    {
        public CompanyOption(Guid id, string? name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string? Name { get; }

        public override string? ToString() => Name;

        public override bool Equals(object obj)
        {
            return obj is CompanyOption other && Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
