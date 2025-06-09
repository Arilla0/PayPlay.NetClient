namespace PayPlay.NetClient.Models.Requests;

using System.Collections.Generic;
using Newtonsoft.Json;
using PayPlay.NetClient.Models.Common;

public class CreateCustomerRequest
{
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
}
