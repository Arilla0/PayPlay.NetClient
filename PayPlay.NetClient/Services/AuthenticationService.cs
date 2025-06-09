using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    public AuthenticationService(HttpClient httpClient, ILogger<AuthenticationService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<AuthTokenResponse> GetTokenAsync(AuthTokenRequest request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Requesting access token");
        return await PostAsync<AuthTokenResponse>("/api/v1/auth/token", request, cancellationToken);
    }

    public async Task<AuthTokenResponse> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Refreshing access token");
        return await PostAsync<AuthTokenResponse>("/api/v1/auth/refresh", request, cancellationToken);
    }

    public async Task<bool> ValidateTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Validating token");
        var response = await PostAsync<dynamic>("/api/v1/auth/validate", new { token }, cancellationToken);
        return response?.valid ?? false;
    }

    public async Task RevokeTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Revoking token");
        await PostAsync<object>("/api/v1/auth/revoke", new { token }, cancellationToken);
    }
}
