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

    public Task<Payout> CancelPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Payout> CreatePayoutAsync(CreatePayoutRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Payout> GetPayoutAsync(string payoutId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Payout>> ListPayoutsAsync(ListPayoutsRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
