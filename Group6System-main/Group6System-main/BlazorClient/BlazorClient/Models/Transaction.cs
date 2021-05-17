using System;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Transaction
    {
        [JsonPropertyName("transactionnumber")]
        public int TransactionNumber { get; set; }
        
        [JsonPropertyName("sender")]
        public Customer Sender { get; set; }
        
        [JsonPropertyName("receiver")]
        public Account Receiver { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("message")]
        public String Message { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("save")]
        public bool Save { get; set; }
        
    }
}