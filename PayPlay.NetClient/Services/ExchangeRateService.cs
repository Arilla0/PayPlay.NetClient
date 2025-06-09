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

    public async Task<List<ExchangeRate>> GetAllExchangeRatesAsync(string baseCurrency, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/exchange-rates/{baseCurrency}";
        return await GetAsync<List<ExchangeRate>>(endpoint, cancellationToken);
    }

    public async Task<ExchangeRate> GetExchangeRateAsync(GetExchangeRateRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/exchange-rates/{request.FromCurrency}/{request.ToCurrency}";
        return await GetAsync<ExchangeRate>(endpoint, cancellationToken);
    }
}
