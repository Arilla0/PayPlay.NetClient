namespace PayPlay.NetClient.Models.Requests;

using PayPlay.NetClient.Models.Common;

public class CreateCustomerRequest
{
    public string Email { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}

public class UpdateCustomerRequest
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public Address? Address { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}

public class ListCustomersRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? Email { get; set; }
    public string? Name { get; set; }
}
