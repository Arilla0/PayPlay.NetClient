namespace PayPlay.NetClient.Models.Requests;

using System;
using PayPlay.NetClient.Models.Common;

public class ListPaymentsRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public PaymentStatus? Status { get; set; }
    public string? CustomerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
