using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class User
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return "User{" +
                   "username=" + Username +
                   "password=" + Password +
                   '}';
        }
    }
}