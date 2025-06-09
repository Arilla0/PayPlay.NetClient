using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class InvoiceService : BaseHttpService, IInvoiceService
{
    public InvoiceService(HttpClient httpClient, ILogger<InvoiceService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<InvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = "/invoices";
        return await PostAsync<InvoiceResponse>(endpoint, request, cancellationToken);
    }

    public async Task DeleteInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        await DeleteAsync(endpoint, cancellationToken);
    }

    public async Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        return await GetAsync<InvoiceResponse>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<InvoiceResponse>> ListInvoicesAsync(ListInvoicesRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<InvoiceResponse>>(endpoint, cancellationToken);
    }

    public async Task<InvoiceResponse> MarkAsPaidAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}/mark-as-paid";
        return await PatchAsync<InvoiceResponse>(endpoint, null, cancellationToken);
    }

    public async Task<InvoiceResponse> SendInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}/send";
        return await PostAsync<InvoiceResponse>(endpoint, null, cancellationToken);
    }

    public async Task<InvoiceResponse> UpdateInvoiceAsync(string invoiceId, UpdateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        return await PutAsync<InvoiceResponse>(endpoint, request, cancellationToken);
    }
}
