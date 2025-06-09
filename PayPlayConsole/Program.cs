using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PayPlay.NetClient;
using PayPlay.NetClient.Configuration;

namespace PayPlayNetClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var payPlayConfig = configuration.GetSection("PayPlayConfiguration").Get<PayPlayConfiguration>();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var payPlayClient = PayPlayNetClient.Create(payPlayConfig, loggerFactory);

            Console.WriteLine("PayPlayNetClient created successfully.");
            Task.Run(async () => 
            {
                try
                {
                    var balances = await payPlayClient.Wallets.GetAllBalancesAsync();
                    Console.WriteLine($"Balances: {JsonConvert.SerializeObject(balances)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during GetAllBalancesAsync: {ex.Message}");
                }
            }).GetAwaiter().GetResult();
        }
    }
}