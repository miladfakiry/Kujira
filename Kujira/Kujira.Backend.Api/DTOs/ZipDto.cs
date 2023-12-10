using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs
{
    public class ZipDto
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("code")]
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonPropertyName("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonPropertyName("canton")]
        [JsonProperty("canton")]
        public string Canton { get; set; }
        [JsonPropertyName("cantonId")]
        [JsonProperty("cantonId")]
        public Guid CantonId { get; set; }

        [JsonPropertyName("country")]
        [JsonProperty("country")]
        public string Country { get; set; }

    }
}
