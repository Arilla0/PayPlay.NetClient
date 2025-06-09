namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;

public class Payment
{
    public string Id { get; set; } = string.Empty;
    public Money Amount { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public PaymentStatus Status { get; set; }
    public string? ReferenceId { get; set; }
    public string? CustomerId { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public string? PaymentUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public string? TransactionHash { get; set; }
}

public class PaymentRefund
{
    public string Id { get; set; } = string.Empty;
    public string PaymentId { get; set; } = string.Empty;
    public Money Amount { get; set; } = new();
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Dictionary<string, string>? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
