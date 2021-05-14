using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Account
    {
        [JsonPropertyName("amount")]
        public int amount{ get; set; }

        [JsonPropertyName("accountID")] 
        public int accountID{ get; set; }
            
        [JsonPropertyName("date")]
        public string date{ get; set; }
        [JsonPropertyName("TransactionNr")]
        private int TransactionNr{ get; set; }
        [JsonPropertyName("username")]
        private string Username{ get; set; }
        [JsonPropertyName("password")]
        private string password { get; set; }
        private Account _account { get; set; }

        public Account(int amount, int accountId, string date, int transactionNr, string username, string password)
        {
            this.amount = amount;
            accountID = accountId;
            this.date = date;
            TransactionNr = transactionNr;
            Username = username;
            this.password = password;
        }

        public Account()
        {
            _account = new Account(); 
        }
    }
}