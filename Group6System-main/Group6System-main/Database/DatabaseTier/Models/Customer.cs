using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Customer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Key]
        [JsonPropertyName("cprnumber")]
        public int CprNumber { get; set; }
        public Address Address { get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
        [JsonPropertyName("countryofresidence")]
        public string CountryOfResidence { get; set; }
       
        public User User { get; set; }
        public Account CustomerAccount{ get; set; }
        public IList<SavedAccounts> SavedAccountsList { get; set; }

        public Customer()
        {
            Address = new Address();
            User = new User();
            CustomerAccount = new Account();
            SavedAccountsList = new List<SavedAccounts>();
        }
        public override string ToString()
        {
            return "Customer{" +
                   "name=" + Name +
                   "cprnumber=" + CprNumber +
                   "streetname=" + Address.StreetName +
                   "streetnumber=" + Address.StreetNumber +
                   "zipcode=" + Address.City.ZipCode + 
                   "cityname=" + Address.City.CityName +
                   "phonenumber=" + PhoneNumber +
                   "email=" + Email +
                   "nationality=" + Nationality +
                   "countryofresidence=" + CountryOfResidence +
                   "username=" + User.Username +
                   "password=" + User.Password +
                   "accountnumber=" + CustomerAccount.AccountNumber +
                   "balance" + CustomerAccount.Balance +
                   '}'; 
        }
    }
}