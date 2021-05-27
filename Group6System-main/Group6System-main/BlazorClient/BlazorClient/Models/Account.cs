using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Account
    {
        [JsonPropertyName("balance")]
        public double Balance{ get; set; }

        [JsonPropertyName("accountNumber")] 
        public long AccountNumber{ get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }
        
        /*[JsonPropertyName("transactions")]
        public IList<Transaction> Transactions { get; set; }*/
        
        [JsonPropertyName("date")]
        public String Date{ get; set; }
    }
}