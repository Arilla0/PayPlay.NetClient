namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;

public class Customer
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal TotalSpent { get; set; }
    public int PaymentCount { get; set; }
}
