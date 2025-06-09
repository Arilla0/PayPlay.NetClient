using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class ExchangeRateService : BaseHttpService, IExchangeRateService
{
    public ExchangeRateService(HttpClient httpClient, ILogger<ExchangeRateService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<List<ExchangeRateResponse>> GetAllExchangeRatesAsync(string baseCurrency, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/exchange-rates/{baseCurrency}";
        return await GetAsync<List<ExchangeRateResponse>>(endpoint, cancellationToken);
    }

    public async Task<ExchangeRateResponse> GetExchangeRateAsync(GetExchangeRateRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/exchange-rates/{request.FromCurrency}/{request.ToCurrency}";
        return await GetAsync<ExchangeRateResponse>(endpoint, cancellationToken);
    }
}
