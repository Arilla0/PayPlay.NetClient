namespace PayPlay.NetClient.Models.Responses;

public class Webhook
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public List<string> Events { get; set; } = new();
    public string? Secret { get; set; }
    public bool Active { get; set; }
    public Dictionary<string, string>? Headers { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? LastTriggeredAt { get; set; }
    public int FailureCount { get; set; }
}

public class WebhookEvent
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public object Data { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
