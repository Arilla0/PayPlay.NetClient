namespace PayPlay.NetClient.Models.Requests;

using PayPlay.NetClient.Models.Common;

public class CreatePaymentRequest
{
    public Money Amount { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string? ReferenceId { get; set; }
    public string? CustomerId { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public string? ReturnUrl { get; set; }
    public string? CancelUrl { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
}

public class PaymentMethod
{
    public string Type { get; set; } = "crypto";
    public string? Currency { get; set; }
    public string? WalletAddress { get; set; }
}

public class RefundPaymentRequest
{
    public Money Amount { get; set; } = new();
    public string Reason { get; set; } = string.Empty;
    public Dictionary<string, string>? Metadata { get; set; }
}

public class ListPaymentsRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public PaymentStatus? Status { get; set; }
    public string? CustomerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
