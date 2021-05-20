using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class City
    {
        [Key, Required]
        [JsonPropertyName("zipcode")]
        public int ZipCode { get; set; }
        
        [JsonPropertyName("cityname")]
        public string CityName { get; set; }
    }
}