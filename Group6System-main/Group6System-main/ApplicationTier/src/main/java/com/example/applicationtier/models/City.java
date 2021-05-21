package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

@Component
public class City {

    @JsonProperty("zipcode")
    private int zipCode;

    @JsonProperty("cityname")
    private String cityName;

    public City() {
    }

    public int getZipCode() {
        return zipCode;
    }

    public void setZipCode(int zipCode) {
        this.zipCode = zipCode;
    }

    public String getCityName() {
        return cityName;
    }

    public void setCityName(String cityName) {
        this.cityName = cityName;
    }
}
