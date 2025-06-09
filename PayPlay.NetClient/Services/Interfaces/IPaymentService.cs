using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(CreatePaymentRequest request, CancellationToken cancellationToken = default);
    Task<Payment> GetPaymentAsync(string paymentId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Payment>> ListPaymentsAsync(ListPaymentsRequest request, CancellationToken cancellationToken = default);
    Task<PaymentRefund> RefundPaymentAsync(string paymentId, RefundPaymentRequest request, CancellationToken cancellationToken = default);
    Task<Payment> CancelPaymentAsync(string paymentId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<PaymentRefund>> ListRefundsAsync(string paymentId, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default);
}
