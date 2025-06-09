using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient.Services;

public class CustomerService : BaseHttpService, ICustomerService
{
    public CustomerService(HttpClient httpClient, ILogger<CustomerService> logger) 
        : base(httpClient, logger)
    {
    }

    public Task<Customer> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<Customer>> ListCustomersAsync(ListCustomersRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> UpdateCustomerAsync(string customerId, UpdateCustomerRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement all interface methods
    // This is a stub implementation that needs to be completed
}
