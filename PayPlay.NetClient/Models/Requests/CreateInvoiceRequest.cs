namespace PayPlay.NetClient.Models.Requests;

using System;
using System.Collections.Generic;
using PayPlay.NetClient.Models.Common;

public class CreateInvoiceRequest
{
    public string CustomerId { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public List<InvoiceItemRequest> Items { get; set; } = new();
    public string? Description { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public Address? BillingAddress { get; set; }
}
