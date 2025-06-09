namespace PayPlay.NetClient.Models.Responses;

public class WebhookEvent
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public object Data { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
