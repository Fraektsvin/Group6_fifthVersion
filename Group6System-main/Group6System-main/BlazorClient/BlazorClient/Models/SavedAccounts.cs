using System;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class SavedAccounts
    {
        [JsonPropertyName("account")]
        public Account SavedAccount { get; set; }
        
        [JsonPropertyName("accountname")]
        public String AccountName { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
    }
}