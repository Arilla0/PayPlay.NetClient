namespace PayPlay.NetClient.Exceptions;

public class PayPlayException : Exception
{
    public int StatusCode { get; set; }
    public string? ErrorCode { get; set; }
    public Dictionary<string, string>? Details { get; set; }

    public PayPlayException(string message) : base(message) { }
    
    public PayPlayException(string message, Exception innerException) 
        : base(message, innerException) { }
    
    public PayPlayException(string message, int statusCode, string? errorCode = null) 
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}

public class PayPlayAuthenticationException : PayPlayException
{
    public PayPlayAuthenticationException(string message) : base(message) { }
}

public class PayPlayValidationException : PayPlayException
{
    public List<string> ValidationErrors { get; set; } = new();
    
    public PayPlayValidationException(string message, List<string> errors) 
        : base(message)
    {
        ValidationErrors = errors;
    }
}

public class PayPlayRateLimitException : PayPlayException
{
    public int? RetryAfterSeconds { get; set; }
    
    public PayPlayRateLimitException(string message, int? retryAfter = null) 
        : base(message)
    {
        RetryAfterSeconds = retryAfter;
    }
}
