using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }
        public Customer Sender { get; set; }
        public Account Receiver { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        public DateTime Date { get; set; }
        [JsonPropertyName("save")]
        public bool Save { get; set; }

        public Transaction()
        {
            Sender = new Customer();
            Receiver = new Account();
        }
        public override string ToString()
        {
            return "Transaction{" +
                   "transactionnumber=" + TransactionNumber +
                   "sender=" + Sender.CustomerAccount +
                   "receiver=" + Receiver.AccountNumber +
                   "amount=" + Amount +
                   "message=" + Message +
                   "save=" + Save +
                   '}';
        }
    }
}