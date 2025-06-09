namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
using PayPlay.NetClient.Models.Common;

public class CreatePayoutRequest
{
    public Money Amount { get; set; } = new();
    public string RecipientId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ReferenceId { get; set; }
    public PayoutMethodRequest PayoutMethod { get; set; } = new();
    public Dictionary<string, string>? Metadata { get; set; }
}
