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

    public async Task<List<WalletBalance>> GetAllBalancesAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = "/wallets/balances";
        return await GetAsync<List<WalletBalance>>(endpoint, cancellationToken);
    }

    public async Task<Wallet> GetWalletAsync(string walletId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets/{walletId}";
        return await GetAsync<Wallet>(endpoint, cancellationToken);
    }

    public async Task<WalletBalance> GetWalletBalanceAsync(string walletId, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets/{walletId}/balance";
        return await GetAsync<WalletBalance>(endpoint, cancellationToken);
    }

    public async Task<PaginatedResponse<Wallet>> ListWalletsAsync(ListWalletsRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"/wallets?{BuildQueryString(request)}";
        return await GetAsync<PaginatedResponse<Wallet>>(endpoint, cancellationToken);
    }
}
