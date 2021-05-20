using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class SavedAccounts
    {
        [Key]
        public int AccountId { get; set; }
        [JsonPropertyName("saveaccount")]
        public Account SaveAccount { get; set; }
        [JsonPropertyName("accountname")]
        public string AccountName { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        /*
         public SavedAccounts()
        {
            SaveAccount = new Account(); 
        }
        */
        
        public override string ToString()
        {
            return "SavedAccounts{" +
                   "accountId=" + AccountId +
                   "accountname=" + AccountName +
                   "amount=" + Amount +
                   "balance=" + SaveAccount.Balance +
                   "accountnumber=" + SaveAccount.AccountNumber +
                   '}';;
        }
    }
}