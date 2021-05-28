using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Account
    {
        [Key, JsonPropertyName("accountNumber")]
        public long AccountNumber { get; set; }
        
        [JsonPropertyName("balance")]
        public double  Balance{ get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("date")]
        public string Date{ get; set; }
        
    }
}