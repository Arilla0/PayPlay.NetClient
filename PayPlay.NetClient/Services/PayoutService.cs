using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class PayoutService : BaseHttpService, IPayoutService
{
    public PayoutService(HttpClient httpClient, ILogger<PayoutService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<Payout> CreatePayoutAsync(CreatePayoutRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = "/payouts";
        return await PostAsync<Payout>(endpoint, request, cancellationToken);
    }

    public async Task<Payout> GetPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts/{payoutId}";
        return await GetAsync<Payout>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<Payout>> ListPayoutsAsync(ListPayoutsRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<Payout>>(endpoint, cancellationToken);
    }

    public async Task<Payout> CancelPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts/{payoutId}/cancel";
        return await PatchAsync<Payout>(endpoint, null, cancellationToken);
    }
}
