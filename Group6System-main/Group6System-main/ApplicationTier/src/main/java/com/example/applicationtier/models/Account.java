package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Date;

public class Account {
    @JsonProperty("balance")
    private double balance;
    @JsonProperty("accountNumber")
    private long accountNumber;
    @JsonProperty("date")
    private Date date;

    public Account(){};

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
