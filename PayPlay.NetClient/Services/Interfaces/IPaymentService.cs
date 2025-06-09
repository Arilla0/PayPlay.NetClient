using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request, CancellationToken cancellationToken = default);
    Task<PaymentResponse> GetPaymentAsync(string paymentId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<PaymentResponse>> ListPaymentsAsync(ListPaymentsRequest request, CancellationToken cancellationToken = default);
    Task<PaymentRefundResponse> RefundPaymentAsync(string paymentId, RefundPaymentRequest request, CancellationToken cancellationToken = default);
    Task<PaymentResponse> CancelPaymentAsync(string paymentId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<PaymentRefundResponse>> ListRefundsAsync(string paymentId, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default);
}
