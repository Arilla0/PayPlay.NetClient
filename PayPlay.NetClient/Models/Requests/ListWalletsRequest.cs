namespace PayPlay.NetClient.Models.Requests;

public class ListWalletsRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? Currency { get; set; }
}
