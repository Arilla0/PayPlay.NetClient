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

    public Task<List<WalletBalance>> GetAllBalancesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Wallet> GetWalletAsync(string walletId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WalletBalance> GetWalletBalanceAsync(string walletId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Wallet>> ListWalletsAsync(ListWalletsRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
