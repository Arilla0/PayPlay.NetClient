namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
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
    public PaymentMethodRequest? PaymentMethod { get; set; }
}
