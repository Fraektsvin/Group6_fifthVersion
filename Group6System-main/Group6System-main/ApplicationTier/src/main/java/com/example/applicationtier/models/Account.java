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
public class Account {
    @JsonProperty("balance")
    private double balance;

    @JsonProperty("accountNumber")
    private long accountNumber;

    @JsonProperty("date")
    private String date;

    @JsonProperty("customer")
    private Customer customer;

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }
}
