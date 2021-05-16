using System;
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
            
        [JsonPropertyName("date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date{ get; set; }

        public Account(double balance, long accountNumber, DateTime date)
        {
            Balance = balance;
            AccountNumber = accountNumber;
            Date = date;
        }
    }
}