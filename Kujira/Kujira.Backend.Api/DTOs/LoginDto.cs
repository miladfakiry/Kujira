using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Api.DTOs
{
    public class LoginDto
    {
        [JsonPropertyName("email")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
