using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IWebhookService
{
    Task<Webhook> CreateWebhookAsync(CreateWebhookRequest request, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Webhook>> ListWebhooksAsync(ListWebhooksRequest request, CancellationToken cancellationToken = default);
    Task DeleteWebhookAsync(string webhookId, CancellationToken cancellationToken = default);
    Task<Webhook> UpdateWebhookAsync(string webhookId, CreateWebhookRequest request, CancellationToken cancellationToken = default);
    Task<bool> ValidateWebhookSignature(string payload, string signature, string secret);
}
