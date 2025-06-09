namespace PayPlay.NetClient.Models.Requests;

public class CreateWebhookRequest
{
    public string Url { get; set; } = string.Empty;
    public List<string> Events { get; set; } = new();
    public string? Secret { get; set; }
    public bool Active { get; set; } = true;
    public Dictionary<string, string>? Headers { get; set; }
}

public class ListWebhooksRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public bool? Active { get; set; }
}
