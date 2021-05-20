using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Account
    {
        [Key, JsonPropertyName("accountnumber")]
        public long AccountNumber { get; set; }
        
        [JsonPropertyName("balance")]
        public double  Balance{ get; set; }
        
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
        
        // [JsonPropertyName("transactions")]
        // public IList<Transaction> Transactions { get; set; }
        
        [JsonPropertyName("date")]
        public String Date{ get; set; }

        public override string ToString()
        {
            return "Account{" +
                   "accountnumber=" + AccountNumber +
                   "balance=" + Balance +
                   "Customer: " + Customer +
                   '}';
            
        }
        
    }
}