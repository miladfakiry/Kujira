using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Kujira.Gui.Api.Response
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
