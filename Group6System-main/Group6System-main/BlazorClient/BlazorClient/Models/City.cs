using System;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class City
    {
        [JsonPropertyName("cityid")]
        public int Id { get; set; }
        
        [JsonPropertyName("zipcode")]
        public int ZipCode { get; set; }
        
        [JsonPropertyName("cityname")]
        public String CityName { get; set; }
    }
}