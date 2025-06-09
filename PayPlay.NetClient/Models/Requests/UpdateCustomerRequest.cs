namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
using PayPlay.NetClient.Models.Common;

public class UpdateCustomerRequest
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}
