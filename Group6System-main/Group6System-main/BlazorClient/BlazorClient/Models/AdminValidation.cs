using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class AdminValidation
    {
        [JsonPropertyName("customeraccount")]
        public Account CustomerAccount { get; set; }
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
    }
}