using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Customer
    {
        [Key]
        [JsonPropertyName("cprnumber")]
        public int CprNumber { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
        
        [JsonPropertyName("countryofresidence")]
        public string CountryOfResidence { get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }
        
        [JsonPropertyName("isvalid")]
        public bool IsValid { get; set; }
        
        [JsonPropertyName("savedaccounts")]
        public IList<SavedAccounts> SavedAccountsList { get; set; }
        
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
                   '}'; 
        }
    }
}