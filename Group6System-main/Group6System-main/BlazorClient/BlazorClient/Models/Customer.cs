using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class Customer 
    {
        [JsonPropertyName("name"), Required]
        public string Name { get; set; }
        
       
        //[Range(1000000000,9999999999,  ErrorMessage = "CPR number must contain 10 numbers")]
        [JsonPropertyName("cprnumber"),Required]
        public long CprNumber { get; set; }
        
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phonenumber"),Required]
        public string PhoneNumber { get; set; }
        
        [JsonPropertyName("email"), Required]
        public string Email { get; set; }
        
        [JsonPropertyName("nationality"), Required]
        public string Nationality { get; set; }
        
        [JsonPropertyName("countryofresidence"),Required]
        public string CountryOfResidence { get; set; }
        [JsonPropertyName("isvalid")]
        public bool IsValid { get; set; }
        
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("savedaccounts")]
        public IList<SavedAccounts> SavedAccounts { get; set; }
        
    }
}