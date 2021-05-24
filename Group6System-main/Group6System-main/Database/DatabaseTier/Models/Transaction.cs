using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Transaction
    {
        [Key, JsonPropertyName("transactionnumber")]
        public int TransactionNumber { get; set; }
        
        [JsonPropertyName("sender")]
        public Account Sender { get; set; }
        
        [JsonPropertyName("receiver")]
        public Account Receiver { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("date")]
        public string Date { get; set; }
        
        [JsonPropertyName("save")]
        public bool Save { get; set; }
        
        public override string ToString()
        {
            return "Transaction{" +
                   "transactionnumber=" + TransactionNumber +
                   "sender=" + Sender.AccountNumber +
                   "receiver=" + Receiver.AccountNumber +
                   "amount=" + Amount +
                   "message=" + Message +
                   "save=" + Save +
                   '}';
        }
    }
}