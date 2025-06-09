namespace PayPlay.NetClient.Models.Requests;

using PayPlay.NetClient.Models.Common;

public class CreateInvoiceRequest
{
    public string CustomerId { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public List<InvoiceItem> Items { get; set; } = new();
    public string? Description { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public Address? BillingAddress { get; set; }
}

public class InvoiceItem
{
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public Money UnitPrice { get; set; } = new();
    public decimal? TaxRate { get; set; }
}

public class UpdateInvoiceRequest
{
    public DateTime? DueDate { get; set; }
    public string? Description { get; set; }
    public InvoiceStatus? Status { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}

public class ListInvoicesRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public InvoiceStatus? Status { get; set; }
    public string? CustomerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
