using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IPayoutService
{
    Task<Payout> CreatePayoutAsync(CreatePayoutRequest request, CancellationToken cancellationToken = default);
    Task<Payout> GetPayoutAsync(string payoutId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Payout>> ListPayoutsAsync(ListPayoutsRequest request, CancellationToken cancellationToken = default);
    Task<Payout> CancelPayoutAsync(string payoutId, CancellationToken cancellationToken = default);
}
