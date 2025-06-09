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

    public async Task<PayoutResponse> CreatePayoutAsync(CreatePayoutRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = "/payouts";
        return await PostAsync<PayoutResponse>(endpoint, request, cancellationToken);
    }

    public async Task<PayoutResponse> GetPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts/{payoutId}";
        return await GetAsync<PayoutResponse>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<PayoutResponse>> ListPayoutsAsync(ListPayoutsRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<PayoutResponse>>(endpoint, cancellationToken);
    }

    public async Task<PayoutResponse> CancelPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/payouts/{payoutId}/cancel";
        return await PatchAsync<PayoutResponse>(endpoint, null, cancellationToken);
    }
}
