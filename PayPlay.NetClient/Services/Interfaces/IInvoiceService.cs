using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IInvoiceService
{
    Task<InvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default);
    Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<InvoiceResponse>> ListInvoicesAsync(ListInvoicesRequest request, CancellationToken cancellationToken = default);
    Task<InvoiceResponse> UpdateInvoiceAsync(string invoiceId, UpdateInvoiceRequest request, CancellationToken cancellationToken = default);
    Task DeleteInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<InvoiceResponse> SendInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<InvoiceResponse> MarkAsPaidAsync(string invoiceId, CancellationToken cancellationToken = default);
}
