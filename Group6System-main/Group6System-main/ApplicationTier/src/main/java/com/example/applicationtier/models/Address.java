package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

@Component
public class Address {
    @JsonProperty("addressId")
    private int addressId;
    @JsonProperty("city")
    private City city;
    @JsonProperty("streetname")
    private String streetName;
    @JsonProperty("streetnumber")
    private String streetNumber;

    public Address(){};

    public City getCity() {
        return city;
    }

    public void setCity(City city) {
        this.city = city;
    }

    public void setStreetName(String streetName) {
        this.streetName = streetName;
    }

    public String getStreetName() {
        return streetName;
    }

    public String getStreetNumber() {
        return streetNumber;
    }

    public void setStreetNumber(String streetNumber) {
        this.streetNumber = streetNumber;
    }

    @Override
    public String toString() {
        return "Address{" +
                "city=" + city +
                ", streetName='" + streetName + '\'' +
                ", streetNumber='" + streetNumber + '\'' +
                '}';
    }
}
