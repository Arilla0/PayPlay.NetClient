namespace PayPlay.NetClient.Models.Requests;

public class ListCustomersRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? Email { get; set; }
    public string? Name { get; set; }
}
