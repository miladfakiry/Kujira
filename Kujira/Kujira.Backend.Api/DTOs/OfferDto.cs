using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs;

public class OfferDto
{
    [JsonPropertyName("id")]
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("availablePlaces")]
    [JsonProperty("availablePlaces")]
    public int AvailablePlaces { get; set; }

    [JsonPropertyName("longTermFamilyCare")]
    [JsonProperty("longTermFamilyCare")]
    public bool LongTermFamilyCare { get; set; }

    [JsonPropertyName("crisisIntervention")]
    [JsonProperty("crisisIntervention")]
    public bool CrisisIntervention { get; set; }

    [JsonPropertyName("reliefOffer")]
    [JsonProperty("reliefOffer")]
    public bool ReliefOffer { get; set; }

    [JsonPropertyName("currentlyPlacedFosterChildren")]
    [JsonProperty("currentlyPlacedFosterChildren")]
    public int CurrentlyPlacedFosterChildren { get; set; }

    [JsonPropertyName("biologicalChildren")]
    [JsonProperty("biologicalChildren")]
    public int BiologicalChildren { get; set; }

    [JsonPropertyName("additionalNote")]
    [JsonProperty("additionalNote")]
    public string AdditionalNote { get; set; }

    [JsonPropertyName("isInactive")]
    [JsonProperty("isInactive")]
    public bool IsInactive { get; set; }

    [JsonPropertyName("zipId")]
    [JsonProperty("zipId")]
    public Guid ZipId { get; set; }

    [JsonPropertyName("userId")]
    [JsonProperty("userId")]
    public Guid UserId { get; set; }

    [JsonPropertyName("phoneNumber")]
    [JsonProperty("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("emailAddress")]
    [JsonProperty("emailAddress")]
    public string? EMailAddress { get; set; }

    [JsonPropertyName("companyName")]
    [JsonProperty("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("zipCode")]
    [JsonProperty("zipCode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("city")]
    [JsonProperty("city")]
    public string? City { get; set; }
}