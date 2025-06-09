using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
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

    public Task<List<ExchangeRate>> GetAllExchangeRatesAsync(string baseCurrency, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ExchangeRate> GetExchangeRateAsync(GetExchangeRateRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
