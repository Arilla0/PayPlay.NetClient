namespace PayPlay.NetClient.Models.Responses;

public class ExchangeRate
{
    public string FromCurrency { get; set; } = string.Empty;
    public string ToCurrency { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }
    public decimal ConvertedAmount { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime ValidUntil { get; set; }
}
