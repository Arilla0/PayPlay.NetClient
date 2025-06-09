using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IExchangeRateService
{
    Task<ExchangeRateResponse> GetExchangeRateAsync(GetExchangeRateRequest request, CancellationToken cancellationToken = default);
    Task<List<ExchangeRateResponse>> GetAllExchangeRatesAsync(string baseCurrency, CancellationToken cancellationToken = default);
}
