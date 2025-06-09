using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IPayoutService
{
    Task<PayoutResponse> CreatePayoutAsync(CreatePayoutRequest request, CancellationToken cancellationToken = default);
    Task<PayoutResponse> GetPayoutAsync(string payoutId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<PayoutResponse>> ListPayoutsAsync(ListPayoutsRequest request, CancellationToken cancellationToken = default);
    Task<PayoutResponse> CancelPayoutAsync(string payoutId, CancellationToken cancellationToken = default);
}
