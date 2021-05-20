package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;

import java.util.List;
@AllArgsConstructor
@NoArgsConstructor
@Data
@Component
public class Customer {
    @JsonProperty("name")
    private String name;

    @JsonProperty("cprnumber")
    private int cprNumber;

    @JsonProperty("address")
    private Address address;

    @JsonProperty("phonenumber")
    private String phoneNumber;

    @JsonProperty("email")
    private String email;

    @JsonProperty("nationality")
    private String nationality;

    @JsonProperty("countryofresidence")
    private String countryOfResidence;

    @JsonProperty("user")
    private User user;

    @JsonProperty("isvalid")
    private boolean isValid;

    @JsonProperty("savedaccounts")
    private List<SavedAccounts> savedAccounts;
}
