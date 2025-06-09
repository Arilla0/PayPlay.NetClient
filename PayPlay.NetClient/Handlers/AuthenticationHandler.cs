using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Configuration;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Handlers;

public class AuthenticationHandler : DelegatingHandler
{
    private readonly PayPlayConfiguration _configuration;
    private readonly ILogger<AuthenticationHandler> _logger;
    private string? _accessToken;
    private DateTime _tokenExpiry = DateTime.MinValue;

    public AuthenticationHandler(
        PayPlayConfiguration configuration,
        ILogger<AuthenticationHandler> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Skip authentication for auth endpoints
        if (request.RequestUri?.AbsolutePath.Contains("/auth/") == true)
        {
            return await base.SendAsync(request, cancellationToken);
        }

        // Ensure we have a valid token
        if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _tokenExpiry)
        {
            await RefreshTokenAsync(cancellationToken);
        }

        // Add authorization header
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            // If unauthorized, try refreshing token once
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _logger.LogWarning("Received 401 Unauthorized, attempting to refresh token");
                await RefreshTokenAsync(cancellationToken);
                
                // Clone the request and retry
                var retryRequest = await CloneHttpRequestMessageAsync(request);
                retryRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                response = await base.SendAsync(retryRequest, cancellationToken);
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during authenticated request");
            throw;
        }
    }

    private async Task RefreshTokenAsync(CancellationToken cancellationToken)
    {
        // This would typically call the authentication service
        // For now, we'll use the API key/secret directly
        // In a real implementation, this would exchange credentials for a token
        _accessToken = Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes($"{_configuration.ApiKey}:{_configuration.ApiSecret}"));
        _tokenExpiry = DateTime.UtcNow.AddHours(1);
    }

    private static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri)
        {
            Version = request.Version
        };

        foreach (var header in request.Headers)
        {
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        if (request.Content != null)
        {
            var ms = new MemoryStream();
            await request.Content.CopyToAsync(ms);
            ms.Position = 0;
            clone.Content = new StreamContent(ms);

            foreach (var header in request.Content.Headers)
            {
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        return clone;
    }
}
