namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PaymentResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("amount")]
    public Money Amount { get; set; } = new();

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("status")]
    public PaymentStatus Status { get; set; }

    [JsonProperty("referenceId")]
    public string? ReferenceId { get; set; }

    [JsonProperty("customerId")]
    public string? CustomerId { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonProperty("paymentUrl")]
    public string? PaymentUrl { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("completedAt")]
    public DateTime? CompletedAt { get; set; }

    [JsonProperty("paymentMethod")]
    public PaymentMethodRequest? PaymentMethod { get; set; }

    [JsonProperty("transactionHash")]
    public string? TransactionHash { get; set; }
}
