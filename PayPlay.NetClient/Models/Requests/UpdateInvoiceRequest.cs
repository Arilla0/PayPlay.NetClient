namespace PayPlay.NetClient.Models.Requests;

using System;
using System.Collections.Generic;
using PayPlay.NetClient.Models.Common;

public class UpdateInvoiceRequest
{
    public DateTime? DueDate { get; set; }
    public string? Description { get; set; }
    public InvoiceStatus? Status { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}
