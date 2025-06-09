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

    public Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Invoice>> ListInvoicesAsync(ListInvoicesRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> MarkAsPaidAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> SendInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> UpdateInvoiceAsync(string invoiceId, UpdateInvoiceRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
