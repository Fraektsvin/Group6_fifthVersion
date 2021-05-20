using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseTier.Models
{
    public class Address
    {
        [Key]
        [JsonPropertyName("streetname")]
        public string StreetName { get; set; }
        [Key]
        [JsonPropertyName("streetnumber")]
        public string StreetNumber { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}