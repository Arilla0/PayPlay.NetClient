using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IWalletService
{
    Task<Wallet> GetWalletAsync(string walletId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Wallet>> ListWalletsAsync(ListWalletsRequest request, CancellationToken cancellationToken = default);
    Task<WalletBalance> GetWalletBalanceAsync(string walletId, CancellationToken cancellationToken = default);
    Task<List<WalletBalance>> GetAllBalancesAsync(CancellationToken cancellationToken = default);
}
