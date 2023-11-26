namespace Kujira.Gui.Api.Requests
{
    public class CompanyRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? AddStreet { get; set; }
        public string? AddStreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? ZipCity { get; set; }
        public string? CantonName { get; set; }
        public string? CountryName { get; set; }
        public string? CompanyTypeName { get; set; }
        
        public string? EMailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebsiteAddress { get; set; }
        public Guid AddressId { get; set; }
        public Guid CompanyTypeId { get; set; }

    }
}
