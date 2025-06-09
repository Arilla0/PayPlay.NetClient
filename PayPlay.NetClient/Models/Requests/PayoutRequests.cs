namespace PayPlay.NetClient.Models.Requests;

using PayPlay.NetClient.Models.Common;

public class CreatePayoutRequest
{
    public Money Amount { get; set; } = new();
    public string RecipientId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ReferenceId { get; set; }
    public PayoutMethod PayoutMethod { get; set; } = new();
    public Dictionary<string, string>? Metadata { get; set; }
}

public class PayoutMethod
{
    public string Type { get; set; } = "crypto";
    public string? Currency { get; set; }
    public string? WalletAddress { get; set; }
    public string? BankAccountId { get; set; }
}

public class ListPayoutsRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public PayoutStatus? Status { get; set; }
    public string? RecipientId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
