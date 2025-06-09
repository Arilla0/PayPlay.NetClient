namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;

public class Payout
{
    public string Id { get; set; } = string.Empty;
    public Money Amount { get; set; } = new();
    public string RecipientId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PayoutStatus Status { get; set; }
    public string? ReferenceId { get; set; }
    public PayoutMethod PayoutMethod { get; set; } = new();
    public Dictionary<string, string>? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? TransactionHash { get; set; }
}
