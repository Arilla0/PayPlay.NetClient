namespace PayPlay.NetClient.Models.Requests;
using Newtonsoft.Json;

public class AuthTokenRequest
{
    [JsonProperty("api_key")]
    public string ApiKey { get; set; } = string.Empty;

    [JsonProperty("api_secret")]
    public string ApiSecret { get; set; } = string.Empty;
}
