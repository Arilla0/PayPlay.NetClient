using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
    Task<CustomerResponse> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<CustomerResponse>> ListCustomersAsync(ListCustomersRequest request, CancellationToken cancellationToken = default);
    Task<CustomerResponse> UpdateCustomerAsync(string customerId, UpdateCustomerRequest request, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default);
}
