namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;

public class Wallet
{
    public string Id { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Money Balance { get; set; } = new();
    public Money AvailableBalance { get; set; } = new();
    public Money PendingBalance { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class WalletBalance
{
    public string WalletId { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public Money TotalBalance { get; set; } = new();
    public Money AvailableBalance { get; set; } = new();
    public Money PendingBalance { get; set; } = new();
    public DateTime AsOf { get; set; }
}
