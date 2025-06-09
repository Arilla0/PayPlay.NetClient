namespace PayPlay.NetClient.Models.Responses;

using PayPlay.NetClient.Models.Common;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CustomerResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("phone")]
    public string? Phone { get; set; }

    [JsonProperty("address")]
    public Address? Address { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("totalSpent")]
    public decimal TotalSpent { get; set; }

    [JsonProperty("paymentCount")]
    public int PaymentCount { get; set; }
}
