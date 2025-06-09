namespace PayPlay.NetClient.Configuration;

public class PayPlayConfiguration
{
    public string BaseUrl { get; set; } = "https://api.payplay.io";
    public string ApiKey { get; set; } = string.Empty;
    public string ApiSecret { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 30;
    public int MaxRetryAttempts { get; set; } = 3;
    public bool EnableLogging { get; set; } = true;
}
