using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class User
    {
        [Key, Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}