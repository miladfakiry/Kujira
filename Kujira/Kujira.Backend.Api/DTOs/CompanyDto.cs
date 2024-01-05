using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs;

public class CompanyDto
{
    [JsonPropertyName("id")]
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonPropertyName("emailAddress")]
    [JsonProperty("emailAddress")]
    public string EMailAddress { get; set; }

    [JsonPropertyName("phoneNumber")]
    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("websiteAddress")]
    [JsonProperty("websiteAddress")]
    public string WebsiteAddress { get; set; }

    [JsonPropertyName("addressId")]
    [JsonProperty("addressId")]
    public Guid AddressId { get; set; }

    [JsonPropertyName("companyTypeId")]
    [JsonProperty("companyTypeId")]
    public Guid CompanyTypeId { get; set; }

    [JsonPropertyName("companyTypeName")]
    [JsonProperty("companyTypeName")]
    public string CompanyType { get; set; }

    [JsonPropertyName("addStreet")]
    [JsonProperty("addStreet")]
    public string Street { get; set; }

    [JsonPropertyName("addStreetNumber")]
    [JsonProperty("addStreetNumber")]
    public string StreetNumber { get; set; }

    [JsonPropertyName("zipCode")]
    [JsonProperty("zipCode")]
    public string ZipCode { get; set; }

    [JsonPropertyName("zipCity")]
    [JsonProperty("zipCity")]
    public string City { get; set; }

    [JsonPropertyName("cantonName")]
    [JsonProperty("canName")]
    public string CantonName { get; set; }

    [JsonPropertyName("countryName")]
    [JsonProperty("couName")]
    public string CountryName { get; set; }
}