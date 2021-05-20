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

        [JsonPropertyName("accountnumber")] 
        public long AccountNumber{ get; set; }
        
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
        
        [JsonPropertyName("transactions")]
        public IList<Transaction> Transactions { get; set; }
        
        [JsonPropertyName("date")]
<<<<<<< Updated upstream
        public String Date{ get; set; }
=======
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date{ get; set; }
>>>>>>> Stashed changes

        public Account(long accountNumber, String name)
        {
            AccountNumber = accountNumber;
            Customer.Name = name;
        }
    }
}