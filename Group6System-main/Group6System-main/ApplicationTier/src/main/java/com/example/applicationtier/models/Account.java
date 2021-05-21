package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;


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

    public void setBalance(double balance) {
        this.balance = balance;
    }

    public void setAccountNumber(long accountNumber) {
        this.accountNumber = accountNumber;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public Account() {
    }

    public double getBalance() {
        return balance;
    }

    public long getAccountNumber() {
        return accountNumber;
    }
}
