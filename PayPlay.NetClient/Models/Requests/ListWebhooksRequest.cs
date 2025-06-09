namespace PayPlay.NetClient.Models.Requests;

public class ListWebhooksRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public bool? Active { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
    public string Status { get; set; }
}
