package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

@Component
public class City {
    public City(){}

    @JsonProperty("cityid")
    private int id;

    @JsonProperty("zipcode")
    private int zipCode;

    @JsonProperty("cityname")
    private String cityName;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

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
