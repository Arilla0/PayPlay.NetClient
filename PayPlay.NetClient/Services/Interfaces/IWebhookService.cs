using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IWebhookService
{
    Task<WebhookResponse> CreateWebhookAsync(CreateWebhookRequest request, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<WebhookResponse>> ListWebhooksAsync(ListWebhooksRequest request, CancellationToken cancellationToken = default);
    Task DeleteWebhookAsync(string webhookId, CancellationToken cancellationToken = default);
    Task<WebhookResponse> UpdateWebhookAsync(string webhookId, CreateWebhookRequest request, CancellationToken cancellationToken = default);
    Task<bool> ValidateWebhookSignature(string payload, string signature, string secret);
}
