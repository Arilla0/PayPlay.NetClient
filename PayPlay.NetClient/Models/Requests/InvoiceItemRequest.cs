namespace PayPlay.NetClient.Models.Requests;
using PayPlay.NetClient.Models.Common;

public class InvoiceItemRequest
{
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public Money UnitPrice { get; set; } = new();
    public decimal? TaxRate { get; set; }
}
