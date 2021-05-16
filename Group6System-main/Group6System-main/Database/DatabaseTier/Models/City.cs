using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class City
    {
        [Key]
        public int ZipCode { get; set; }
        [JsonPropertyName("cityname")]
        public string CityName { get; set; }

        public override string ToString()
        {
            return "City{" +
                   "zipcode=" + ZipCode +
                   "cityname=" + CityName +
                   '}';
        }
    }
}