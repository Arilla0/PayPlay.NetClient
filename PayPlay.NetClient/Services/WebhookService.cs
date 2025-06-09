namespace PayPlay.NetClient.Models.Requests;
using System.Security.Cryptography;
using System.Text;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services;
using PayPlay.NetClient.Services.Interfaces;
using Microsoft.Extensions.Logging;


public class WebhookService : BaseHttpService, IWebhookService
{
    public WebhookService(HttpClient httpClient, ILogger<WebhookService> logger)
        : base(httpClient, logger)
    {
    }

    public async Task<WebhookResponse> CreateWebhookAsync(CreateWebhookRequest request, CancellationToken cancellationToken = default)
    {
        return await PostAsync<WebhookResponse>("webhooks", request, cancellationToken);
    }

    public async Task DeleteWebhookAsync(string webhookId, CancellationToken cancellationToken = default)
    {
        await DeleteAsync($"webhooks/{webhookId}", cancellationToken);
    }

    public async Task<PaginatedResponse<WebhookResponse>> ListWebhooksAsync(ListWebhooksRequest request, CancellationToken cancellationToken = default)
    {
        var queryString = BuildQueryString(request);
        return await GetAsync<PaginatedResponse<WebhookResponse>>($"webhooks{queryString}", cancellationToken);
    }

    public async Task<WebhookResponse> UpdateWebhookAsync(string webhookId, CreateWebhookRequest request, CancellationToken cancellationToken = default)
    {
        return await PutAsync<WebhookResponse>($"webhooks/{webhookId}", request, cancellationToken);
    }

    public Task<bool> ValidateWebhookSignature(string payload, string signature, string secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        var computedSignature = Convert.ToBase64String(computedHash);

        return Task.FromResult(signature.Equals(computedSignature, StringComparison.Ordinal));
    }

    private static string BuildQueryString(ListWebhooksRequest request)
    {
        var queryParams = new List<string>();

        if (request.Limit.HasValue)
            queryParams.Add($"limit={request.Limit.Value}");

        if (request.Offset.HasValue)
            queryParams.Add($"offset={request.Offset.Value}");

        if (!string.IsNullOrEmpty(request.Status))
            queryParams.Add($"status={Uri.EscapeDataString(request.Status)}");

        return queryParams.Any() ? $"?{string.Join("&", queryParams)}" : string.Empty;
    }
}
