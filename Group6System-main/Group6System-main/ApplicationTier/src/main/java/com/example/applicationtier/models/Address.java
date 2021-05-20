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
public class Address {
    @JsonProperty("city")
    private City city;

    @JsonProperty("streetname")
    private String streetName;

    @JsonProperty("streetnumber")
    private String streetNumber;
}
