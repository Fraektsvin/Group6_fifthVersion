using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Notification
    {
        [Key, Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
    }
}