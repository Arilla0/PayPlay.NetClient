namespace PayPlay.NetClient.Models.Responses;
using System.Collections.Generic;
using Newtonsoft.Json;

public class WebhookResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("events")]
    public List<string> Events { get; set; } = new();

    [JsonProperty("secret")]
    public string? Secret { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("lastTriggeredAt")]
    public DateTime? LastTriggeredAt { get; set; }

    [JsonProperty("failureCount")]
    public int FailureCount { get; set; }
}
