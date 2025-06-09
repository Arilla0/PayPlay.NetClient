using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;

namespace PayPlay.NetClient.Services.Interfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
    Task<Customer> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<Customer>> ListCustomersAsync(ListCustomersRequest request, CancellationToken cancellationToken = default);
    Task<Customer> UpdateCustomerAsync(string customerId, UpdateCustomerRequest request, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default);
}
