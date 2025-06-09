using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class WebhookService : BaseHttpService, IWebhookService
{
    public WebhookService(HttpClient httpClient, ILogger<WebhookService> logger) 
        : base(httpClient, logger)
    {
    }

    public Task<Webhook> CreateWebhookAsync(CreateWebhookRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteWebhookAsync(string webhookId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Webhook>> ListWebhooksAsync(ListWebhooksRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Webhook> UpdateWebhookAsync(string webhookId, CreateWebhookRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateWebhookSignature(string payload, string signature, string secret)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
