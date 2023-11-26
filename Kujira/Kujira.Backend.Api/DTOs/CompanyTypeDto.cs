using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs
{
    public class CompanyTypeDto
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("type")]
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
