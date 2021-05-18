package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

@Component
public class City {
    public City(){}



    @JsonProperty("zipcode")
    private int zipCode;

    @JsonProperty("cityname")
    private String cityName;



    public void setZipCode(int zipCode) {
        this.zipCode = zipCode;
    }

    public int getZipCode() {
        return zipCode;
    }

    public void setCityName(String cityName) {
        this.cityName = cityName;
    }

    public String getCityName() {
        return cityName;
    }


    @Override
    public String toString() {
        return "City{" +
                "zipCode=" + zipCode +
                ", cityName='" + cityName + '\'' +
                '}';
    }
}
