namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using PayPlay.NetClient.Models.Requests;

public class Invoice
{
    public string Id { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public InvoiceStatus Status { get; set; }
    public DateTime DueDate { get; set; }
    public List<InvoiceItem> Items { get; set; } = new();
    public Money Subtotal { get; set; } = new();
    public Money TaxAmount { get; set; } = new();
    public Money Total { get; set; } = new();
    public Money AmountPaid { get; set; } = new();
    public Money AmountDue { get; set; } = new();
    public string? Description { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public Address? BillingAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public string? PaymentUrl { get; set; }
}
