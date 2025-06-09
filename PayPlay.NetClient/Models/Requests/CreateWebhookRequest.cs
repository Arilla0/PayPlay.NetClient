namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
using Newtonsoft.Json;

public class CreateWebhookRequest
{
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("events")]
    public List<string> Events { get; set; } = new();

    [JsonProperty("secret")]
    public string? Secret { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; } = true;

    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }
}
