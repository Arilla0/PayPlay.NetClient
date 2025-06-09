namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;
using System.Collections.Generic;
using Newtonsoft.Json;

public class InvoiceResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("customerId")]
    public string CustomerId { get; set; } = string.Empty;

    [JsonProperty("invoiceNumber")]
    public string InvoiceNumber { get; set; } = string.Empty;

    [JsonProperty("status")]
    public InvoiceStatus Status { get; set; }

    [JsonProperty("dueDate")]
    public DateTime DueDate { get; set; }

    [JsonProperty("items")]
    public List<InvoiceItemRequest> Items { get; set; } = new();

    [JsonProperty("subtotal")]
    public Money Subtotal { get; set; } = new();

    [JsonProperty("taxAmount")]
    public Money TaxAmount { get; set; } = new();

    [JsonProperty("total")]
    public Money Total { get; set; } = new();

    [JsonProperty("amountPaid")]
    public Money AmountPaid { get; set; } = new();

    [JsonProperty("amountDue")]
    public Money AmountDue { get; set; } = new();

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonProperty("billingAddress")]
    public Address? BillingAddress { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("paidAt")]
    public DateTime? PaidAt { get; set; }

    [JsonProperty("paymentUrl")]
    public string? PaymentUrl { get; set; }
}
