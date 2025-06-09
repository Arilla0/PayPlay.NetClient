namespace PayPlay.NetClient.Models.Requests;

public class PayoutMethodRequest
{
    public string Type { get; set; } = "crypto";
    public string? Currency { get; set; }
    public string? WalletAddress { get; set; }
    public string? BankAccountId { get; set; }
}
