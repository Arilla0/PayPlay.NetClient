using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class PaymentService : BaseHttpService, IPaymentService
{
    public PaymentService(HttpClient httpClient, ILogger<PaymentService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Creating payment with amount {Amount} {Currency}", request.Amount.Amount, request.Amount.Currency);
        return await PostAsync<PaymentResponse>("/api/v1/payments", request, cancellationToken);
    }

    public async Task<PaymentResponse> GetPaymentAsync(string paymentId, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Getting payment {PaymentId}", paymentId);
        return await GetAsync<PaymentResponse>($"/api/v1/payments/{paymentId}", cancellationToken);
    }

    public async Task<PaginatedResponse<PaymentResponse>> ListPaymentsAsync(ListPaymentsRequest request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Listing payments with filters");
        var queryString = BuildQueryString(request);
        return await GetAsync<PaginatedResponse<PaymentResponse>>($"/api/v1/payments?{queryString}", cancellationToken);
    }

    public async Task<PaymentRefundResponse> RefundPaymentAsync(string paymentId, RefundPaymentRequest request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Refunding payment {PaymentId} with amount {Amount}", paymentId, request.Amount.Amount);
        return await PostAsync<PaymentRefundResponse>($"/api/v1/payments/{paymentId}/refunds", request, cancellationToken);
    }

    public async Task<PaymentResponse> CancelPaymentAsync(string paymentId, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Cancelling payment {PaymentId}", paymentId);
        return await PostAsync<PaymentResponse>($"/api/v1/payments/{paymentId}/cancel", null, cancellationToken);
    }

    public async Task<PaginatedResponse<PaymentRefundResponse>> ListRefundsAsync(string paymentId, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Listing refunds for payment {PaymentId}", paymentId);
        return await GetAsync<PaginatedResponse<PaymentRefundResponse>>($"/api/v1/payments/{paymentId}/refunds?page={page}&pageSize={pageSize}", cancellationToken);
    }
}
