using PayPlay.NetClient.Services.Interfaces;

namespace PayPlay.NetClient;

public interface IPayPlayNetClient
{
    IAuthenticationService Authentication { get; }
    IPaymentService Payments { get; }
    IPayoutService Payouts { get; }
    IInvoiceService Invoices { get; }
    ICustomerService Customers { get; }
    IWalletService Wallets { get; }
    IExchangeRateService ExchangeRates { get; }
    IWebhookService Webhooks { get; }
}
