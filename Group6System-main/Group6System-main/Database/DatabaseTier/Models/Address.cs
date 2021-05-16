﻿using System.ComponentModel.DataAnnotations;
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