using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Exceptions;
using PayPlay.NetClient.Models.Common;

namespace PayPlay.NetClient.Services;

public abstract class BaseHttpService
{
    protected readonly HttpClient HttpClient;
    protected readonly ILogger Logger;
    protected readonly JsonSerializerOptions JsonOptions;

    protected BaseHttpService(HttpClient httpClient, ILogger logger)
    {
        HttpClient = httpClient;
        Logger = logger;
        
        JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    protected async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await HttpClient.GetAsync(endpoint, cancellationToken);
            return await HandleResponseAsync<T>(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error during GET request to {Endpoint}", endpoint);
            throw;
        }
    }

    protected async Task<T> PostAsync<T>(string endpoint, object? request = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var content = request != null 
                ? new StringContent(JsonSerializer.Serialize(request, JsonOptions), Encoding.UTF8, "application/json")
                : null;

            var response = await HttpClient.PostAsync(endpoint, content, cancellationToken);
            return await HandleResponseAsync<T>(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error during POST request to {Endpoint}", endpoint);
            throw;
        }
    }

    protected async Task<T> PutAsync<T>(string endpoint, object request, CancellationToken cancellationToken = default)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(request, JsonOptions), Encoding.UTF8, "application/json");
            var response = await HttpClient.PutAsync(endpoint, content, cancellationToken);
            return await HandleResponseAsync<T>(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error during PUT request to {Endpoint}", endpoint);
            throw;
        }
    }

    protected async Task<T> PatchAsync<T>(string endpoint, object request, CancellationToken cancellationToken = default)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(request, JsonOptions), Encoding.UTF8, "application/json");
            var response = await HttpClient.PatchAsync(endpoint, content, cancellationToken);
            return await HandleResponseAsync<T>(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error during PATCH request to {Endpoint}", endpoint);
            throw;
        }
    }

    protected async Task DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await HttpClient.DeleteAsync(endpoint, cancellationToken);
            await HandleResponseAsync<object>(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error during DELETE request to {Endpoint}", endpoint);
            throw;
        }
    }

    private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            HandleErrorResponse(response, content);
        }

        if (string.IsNullOrWhiteSpace(content) || response.StatusCode == HttpStatusCode.NoContent)
        {
            return default!;
        }

        try
        {
            var result = JsonSerializer.Deserialize<T>(content, JsonOptions);
            return result!;
        }
        catch (JsonException ex)
        {
            Logger.LogError(ex, "Failed to deserialize response: {Content}", content);
            throw new PayPlayException("Failed to parse API response", ex);
        }
    }

    private void HandleErrorResponse(HttpResponseMessage response, string content)
    {
        var statusCode = (int)response.StatusCode;
        var errorMessage = "API request failed";

        try
        {
            var errorResponse = JsonSerializer.Deserialize<ApiResponse<object>>(content, JsonOptions);
            if (errorResponse?.Message != null)
            {
                errorMessage = errorResponse.Message;
            }
        }
        catch
        {
            // If we can't parse the error response, use the raw content
            errorMessage = string.IsNullOrWhiteSpace(content) ? response.ReasonPhrase ?? errorMessage : content;
        }

        throw response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => new PayPlayAuthenticationException(errorMessage),
            HttpStatusCode.BadRequest => new PayPlayValidationException(errorMessage, new List<string>()),
            HttpStatusCode.TooManyRequests => new PayPlayRateLimitException(errorMessage),
            _ => new PayPlayException(errorMessage, statusCode)
        };
    }

    internal string BuildQueryString(object parameters)
    {
        var properties = parameters.GetType().GetProperties()
            .Where(p => p.GetValue(parameters) != null)
            .Select(p => $"{p.Name}={Uri.EscapeDataString(p.GetValue(parameters)!.ToString()!)}");

        return string.Join("&", properties);
    }
}
