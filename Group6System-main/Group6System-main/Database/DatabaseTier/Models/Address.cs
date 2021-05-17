using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Address
    {
        [Key]
        [JsonPropertyName("addressid")]
        public int Id { get; set; }
        
        [JsonPropertyName("streetname")]
        public string StreetName { get; set; }
        
        [JsonPropertyName("streetnumber")]
        public string StreetNumber { get; set; }
        
        [JsonPropertyName("city")]
        public City City { get; set; }

        public Address()
        {
            City = new City();
        }

        public override string ToString()
        {
            return "Address{" +
                   "streetname=" + StreetName +
                   "streetnumber=" + StreetNumber +
                   "zipcode=" + City.ZipCode + 
                   "cityname" + City.CityName + 
                   '}';
        }
    }
}