namespace Kujira.Gui.Api.Requests
{
    public class CompanyTypeRequest
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public CompanyTypeRequest() { }

        public CompanyTypeRequest(Guid id, string type)
        {
            Id = id;
            Type = type;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
