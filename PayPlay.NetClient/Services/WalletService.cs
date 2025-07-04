using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class WalletService : BaseHttpService, IWalletService
{
    public WalletService(HttpClient httpClient, ILogger<WalletService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<List<WalletBalanceResponse>> GetAllBalancesAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = "/wallets/balances";
        return await GetAsync<List<WalletBalanceResponse>>(endpoint, cancellationToken);
    }

    public async Task<WalletResponse> GetWalletAsync(string walletId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets/{walletId}";
        return await GetAsync<WalletResponse>(endpoint, cancellationToken);
    }

    public async Task<WalletBalanceResponse> GetWalletBalanceAsync(string walletId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets/{walletId}/balance";
        return await GetAsync<WalletBalanceResponse>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<WalletResponse>> ListWalletsAsync(ListWalletsRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<WalletResponse>>(endpoint, cancellationToken);
    }
}
