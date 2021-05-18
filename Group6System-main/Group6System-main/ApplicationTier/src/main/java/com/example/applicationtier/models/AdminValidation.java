package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;
import org.springframework.stereotype.Component;

@Component
public class AdminValidation {
    @JsonProperty("customeraccount")
    @JsonSetter
    private Account account;

    @JsonProperty("customer")
    @JsonSetter
    private Customer customer;

    @Override
    public String toString() {
        return "AdminValidation{" +
                "account=" + account +
                ", customer=" + customer +
                '}';
    }
}
