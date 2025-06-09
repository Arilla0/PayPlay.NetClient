using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayPlay.NetClient.Configuration;
using PayPlay.NetClient.Extensions;
using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient;

public class PayPlayNetClient : IPayPlayNetClient
{
    public IAuthenticationService Authentication { get; }
    public IPaymentService Payments { get; }
    public IPayoutService Payouts { get; }
    public IInvoiceService Invoices { get; }
    public ICustomerService Customers { get; }
    public IWalletService Wallets { get; }
    public IExchangeRateService ExchangeRates { get; }
    public IWebhookService Webhooks { get; }

    public PayPlayNetClient(
        IAuthenticationService authentication,
        IPaymentService payments,
        IPayoutService payouts,
        IInvoiceService invoices,
        ICustomerService customers,
        IWalletService wallets,
        IExchangeRateService exchangeRates,
        IWebhookService webhooks)
    {
        Authentication = authentication;
        Payments = payments;
        Payouts = payouts;
        Invoices = invoices;
        Customers = customers;
        Wallets = wallets;
        ExchangeRates = exchangeRates;
        Webhooks = webhooks;
    }

    public static PayPlayNetClient Create(PayPlayConfiguration configuration, ILoggerFactory? loggerFactory = null)
    {
        var services = new ServiceCollection();
        services.AddPayPlayClient(configuration, loggerFactory);
        
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<IPayPlayNetClient>() as PayPlayNetClient 
            ?? throw new InvalidOperationException("Failed to create PayPlayClient");
    }
}
