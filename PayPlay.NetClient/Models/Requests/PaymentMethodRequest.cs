namespace PayPlay.NetClient.Models.Requests;

public class PaymentMethodRequest
{
    public string Type { get; set; } = "crypto";
    public string? Currency { get; set; }
    public string? WalletAddress { get; set; }
}
