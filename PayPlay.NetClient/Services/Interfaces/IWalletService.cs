using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface IWalletService
{
    Task<WalletResponse> GetWalletAsync(string walletId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<WalletResponse>> ListWalletsAsync(ListWalletsRequest request, CancellationToken cancellationToken = default);
    Task<WalletBalanceResponse> GetWalletBalanceAsync(string walletId, CancellationToken cancellationToken = default);
    Task<List<WalletBalanceResponse>> GetAllBalancesAsync(CancellationToken cancellationToken = default);
}
