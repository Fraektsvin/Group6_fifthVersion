using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Customer 
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("cprnumber")]
        public int CprNumber { get; set; }
        
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

        [JsonPropertyName("savedaccounts")]
        public IList<SavedAccounts> SavedAccounts { get; set; }
        
        
    }
}