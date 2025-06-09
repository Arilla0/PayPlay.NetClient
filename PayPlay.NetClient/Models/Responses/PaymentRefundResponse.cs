namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using System.Collections.Generic;

public class PaymentRefundResponse
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
