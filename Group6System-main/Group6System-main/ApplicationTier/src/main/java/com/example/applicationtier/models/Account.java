package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

import java.util.Date;
@Component
public class Account {
    @JsonProperty("balance")
    private double balance;

    @JsonProperty("accountNumber")
    private long accountNumber;

    @JsonProperty("date")
    private Date date;

    @JsonProperty("customer")
    private Customer customer;

    public Account(){};

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public Account(double balance, long accountNumber, Date date) {
        this.balance = balance;
        this.accountNumber = accountNumber;
        this.date = date;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }

    public double getBalance() {
        return balance;
    }

    public void setAccountNumber(long accountNumber) {
        this.accountNumber = accountNumber;
    }

    public long getAccountNumber() {
        return accountNumber;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    @Override
    public String toString() {
        return "Account{" +
                "balance=" + balance +
                ", accountLong=" + accountNumber +
                ", date=" + date +
                '}';
    }
}
