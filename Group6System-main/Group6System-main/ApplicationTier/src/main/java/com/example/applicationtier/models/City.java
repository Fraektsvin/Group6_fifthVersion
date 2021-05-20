package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;
@AllArgsConstructor
@NoArgsConstructor
@Data
@Component
public class City {

    @JsonProperty("zipcode")
    private int zipCode;

    @JsonProperty("cityname")
    private String cityName;
}
