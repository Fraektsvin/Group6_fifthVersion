package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;

@AllArgsConstructor
@NoArgsConstructor
@Data
@Component
public class AdminValidation {
    @JsonProperty("customeraccount")
    private Account account;
    @JsonProperty("customer")
    private Customer customer;
}
