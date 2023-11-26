namespace Kujira.Gui.Api.Requests
{
    public class ZipRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Canton { get; set; }
        public string Country { get; set; }

        public Guid CountryId { get; set; }
        public Guid CantonId { get; set; }


        public ZipRequest()
        {

        }

        public ZipRequest(Guid id, string code, string city,Guid cantonId, string canton, Guid countryId, string country)
        {
            Id = id;
            Code = code;
            City = city;
            Canton = canton;
            CantonId = cantonId;
            Country = country;
            CountryId = countryId;

        }

        public override string ToString()
        {
            return Code;
        }
    }
}
