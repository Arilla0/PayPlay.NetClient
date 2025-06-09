using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Responses;
using PayPlay.NetClient.Services.Interfaces;
using System.Net.Http.Json;

namespace PayPlay.NetClient.Services;

public class CustomerService : BaseHttpService, ICustomerService
{
    public CustomerService(HttpClient httpClient, ILogger<CustomerService> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsJsonAsync("customers", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>(cancellationToken: cancellationToken);
    }

    public async Task DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.DeleteAsync($"customers/{customerId}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<CustomerResponse> GetCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync($"customers/{customerId}", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>(cancellationToken: cancellationToken);
    }

    public async Task<PaginatedResponse<CustomerResponse>> ListCustomersAsync(ListCustomersRequest request, CancellationToken cancellationToken = default)
    {
        var query = BuildQueryString(request);
        var response = await HttpClient.GetAsync($"customers?{query}", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PaginatedResponse<CustomerResponse>>(cancellationToken: cancellationToken);
    }

    public async Task<CustomerResponse> UpdateCustomerAsync(string customerId, UpdateCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PutAsJsonAsync($"customers/{customerId}", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>(cancellationToken: cancellationToken);
    }
}
