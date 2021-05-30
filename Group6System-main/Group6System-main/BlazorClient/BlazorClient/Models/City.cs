using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorClient.Models
{
    public class City
    {
        [JsonPropertyName("zipcode")]
        public int ZipCode { get; set; }
        
        [JsonPropertyName("cityname")]
        public String CityName { get; set; }
    }
}