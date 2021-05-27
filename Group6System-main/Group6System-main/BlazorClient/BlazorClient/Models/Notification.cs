using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Notification
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}