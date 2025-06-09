namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
using PayPlay.NetClient.Models.Common;

public class RefundPaymentRequest
{
    public Money Amount { get; set; } = new();
    public string Reason { get; set; } = string.Empty;
    public Dictionary<string, string>? Metadata { get; set; }
}
