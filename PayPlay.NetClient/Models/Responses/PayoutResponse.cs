namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PayoutResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("amount")]
    public Money Amount { get; set; } = new();

    [JsonProperty("recipientId")]
    public string RecipientId { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("status")]
    public PayoutStatus Status { get; set; }

    [JsonProperty("referenceId")]
    public string? ReferenceId { get; set; }

    [JsonProperty("payoutMethod")]
    public PayoutMethodRequest PayoutMethod { get; set; } = new();

    [JsonProperty("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("completedAt")]
    public DateTime? CompletedAt { get; set; }

    [JsonProperty("transactionHash")]
    public string? TransactionHash { get; set; }
}
