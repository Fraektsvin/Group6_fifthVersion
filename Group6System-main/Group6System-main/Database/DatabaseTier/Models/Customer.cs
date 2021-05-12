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
        [JsonPropertyName("address")]
        public string Address { get; set; }
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

        public Customer()
        {
            User = new User(); 
        }

        public override string ToString()
        {
            return "Customer{" +
                   "name='" + Name + '\'' +
                   ", cprNumber='" + CprNumber + '\'' +
                   ", address='" + Address + '\'' +
                   ", phoneNumber=" + PhoneNumber +
                   ", email='" + Email + '\'' +
                   ", nationality='" + Nationality + '\'' +
                   ", countryOfResidence='" + CountryOfResidence + '\'' +
                   ", user=" + User +
                   '}';
        }
    }
}