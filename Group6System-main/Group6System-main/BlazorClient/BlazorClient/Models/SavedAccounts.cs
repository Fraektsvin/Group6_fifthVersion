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

        public SavedAccounts(Account savedAccount, string accountName, double amount)
        {
            SavedAccount = savedAccount;
            AccountName = accountName;
            Amount = amount;
        }
    }
}