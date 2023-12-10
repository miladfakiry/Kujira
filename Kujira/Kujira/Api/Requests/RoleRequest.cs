namespace Kujira.Gui.Api.Requests
{
    public class RoleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public RoleRequest() { }

        public RoleRequest(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
