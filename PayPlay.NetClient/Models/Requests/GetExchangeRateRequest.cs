namespace PayPlay.NetClient.Models.Requests;

public class GetExchangeRateRequest
{
    public string FromCurrency { get; set; } = string.Empty;
    public string ToCurrency { get; set; } = string.Empty;
    public decimal? Amount { get; set; }
}
