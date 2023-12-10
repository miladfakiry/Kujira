using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs
{
    public class RoleDto
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
