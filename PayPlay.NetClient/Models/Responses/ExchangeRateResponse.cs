namespace PayPlay.NetClient.Models.Responses;
using Newtonsoft.Json;

public class ExchangeRateResponse
{
    [JsonProperty("fromCurrency")]
    public string FromCurrency { get; set; } = string.Empty;

    [JsonProperty("toCurrency")]
    public string ToCurrency { get; set; } = string.Empty;

    [JsonProperty("rate")]
    public decimal Rate { get; set; }

    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

    [JsonProperty("convertedAmount")]
    public decimal? ConvertedAmount { get; set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty("validUntil")]
    public DateTime ValidUntil { get; set; }
}