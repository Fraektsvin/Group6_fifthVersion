using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Account
    {
        [JsonPropertyName("amount")]
        private int amount{ get; set; }
        [JsonPropertyName("accountID")]
        private int accountID{ get; set; }
        [JsonPropertyName("date")]
        private string date{ get; set; }
        [JsonPropertyName("TranasctionNR")]
        private int TransactionNr{ get; set; }
        [JsonPropertyName("username")]
        private string Username{ get; set; }
        [JsonPropertyName("password")]
        private string password { get; set; }

        public override string ToString()
        {
            return "Account{" +
                   "amount=" + amount +
                   "accountID=" + accountID +
                   "date=" + date +
                   "TranasctionNR=" + TransactionNr +
                   "username=" + Username +
                   "password=" + password +
                   '}';
        }


        public Account()
        {
        }
    }
}