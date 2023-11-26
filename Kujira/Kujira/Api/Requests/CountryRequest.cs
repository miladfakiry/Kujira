namespace Kujira.Gui.Api.Requests
{
    public class CountryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CountryRequest()
        {

        }

        public CountryRequest(Guid id, string name)
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
