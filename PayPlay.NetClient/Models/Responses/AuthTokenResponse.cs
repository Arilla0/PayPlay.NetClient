namespace PayPlay.NetClient.Models.Responses;
using Newtonsoft.Json;

public class AuthTokenResponse
{
    [JsonProperty("accessToken")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonProperty("refreshToken")]
    public string RefreshToken { get; set; } = string.Empty;

    [JsonProperty("expiresIn")]
    public int ExpiresIn { get; set; }

    [JsonProperty("tokenType")]
    public string TokenType { get; set; } = "Bearer";
}
