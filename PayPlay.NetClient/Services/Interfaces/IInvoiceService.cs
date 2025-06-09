using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default);
    Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Invoice>> ListInvoicesAsync(ListInvoicesRequest request, CancellationToken cancellationToken = default);
    Task<Invoice> UpdateInvoiceAsync(string invoiceId, UpdateInvoiceRequest request, CancellationToken cancellationToken = default);
    Task DeleteInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<Invoice> SendInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default);
    Task<Invoice> MarkAsPaidAsync(string invoiceId, CancellationToken cancellationToken = default);
}
