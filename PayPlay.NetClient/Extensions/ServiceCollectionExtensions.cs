using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using PayPlay.NetClient.Configuration;
using PayPlay.NetClient.Handlers;
using PayPlay.NetClient.Services;
using PayPlay.NetClient.Services.Interfaces;
using Polly.Extensions.Http;
using PayPlay.NetClient.Models.Requests;

namespace PayPlay.NetClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPayPlayClient(
        this IServiceCollection services,
        PayPlayConfiguration configuration,
        ILoggerFactory? loggerFactory = null)
    {
        // Add configuration
        services.AddSingleton(configuration);

        // Add logging
        if (loggerFactory != null)
        {
            services.AddSingleton(loggerFactory);
        }
        else
        {
            services.AddLogging();
        }

        // Add authentication handler
        services.AddTransient<AuthenticationHandler>();

        // Configure HttpClient with Polly retry policies
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                configuration.MaxRetryAttempts,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (outcome, timespan, retryCount, context) =>
                {
                    var found = context.Values.FirstOrDefault("logger") as ILogger;
                    var logger = found!= null ? found : null;
                    logger?.LogWarning("Retry {RetryCount} after {Delay}ms", retryCount, timespan.TotalMilliseconds);
                });

        // Register HTTP clients for each service
        services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IPaymentService, PaymentService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IPayoutService, PayoutService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IInvoiceService, InvoiceService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<ICustomerService, CustomerService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IWalletService, WalletService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IExchangeRateService, ExchangeRateService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        services.AddHttpClient<IWebhookService, WebhookService>(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "PayPlay.NetClient/1.0.0");
        })
        .AddHttpMessageHandler<AuthenticationHandler>()
        .AddPolicyHandler(retryPolicy);

        // Register main client
        services.AddSingleton<IPayPlayNetClient, PayPlayNetClient>();

        return services;
    }
}
