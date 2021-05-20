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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public String Date{ get; set; }
=======
       // [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       public DateTime Date{ get; set; }
>>>>>>> Stashed changes
=======
       // [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       public DateTime Date{ get; set; }
>>>>>>> Stashed changes

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