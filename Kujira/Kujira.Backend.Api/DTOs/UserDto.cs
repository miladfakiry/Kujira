using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Kujira.Backend.Api.DTOs
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("isInactive")]
        [JsonProperty("isInactive")]
        public bool IsInactive { get; set; }

        [JsonPropertyName("createDate")]
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        // Persönliche Informationen
        [JsonPropertyName("dateOfBirth")]
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("phoneNumber")]
        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        
        [JsonPropertyName("companyId")]
        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }


    }
}