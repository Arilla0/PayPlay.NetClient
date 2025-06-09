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

    public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = "/invoices";
        return await PostAsync<Invoice>(endpoint, request, cancellationToken);
    }

    public async Task DeleteInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        await DeleteAsync(endpoint, cancellationToken);
    }

    public async Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        return await GetAsync<Invoice>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<Invoice>> ListInvoicesAsync(ListInvoicesRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<Invoice>>(endpoint, cancellationToken);
    }

    public async Task<Invoice> MarkAsPaidAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}/mark-as-paid";
        return await PatchAsync<Invoice>(endpoint, null, cancellationToken);
    }

    public async Task<Invoice> SendInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}/send";
        return await PostAsync<Invoice>(endpoint, null, cancellationToken);
    }

    public async Task<Invoice> UpdateInvoiceAsync(string invoiceId, UpdateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/invoices/{invoiceId}";
        return await PutAsync<Invoice>(endpoint, request, cancellationToken);
    }
}
