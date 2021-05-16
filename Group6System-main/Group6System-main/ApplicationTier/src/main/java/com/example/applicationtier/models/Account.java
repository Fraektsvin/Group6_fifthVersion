package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Account {
    @JsonProperty("amount")
    private int amount;
    @JsonProperty("accountID")
    private int accountID;
    @JsonProperty("date")
    private String date;
    @JsonProperty("TransactionNr")
    private int TransactionNr;
    @JsonProperty("username")
    private String Username;
    @JsonProperty("password")
    private String password;


    public Account(int amount, int accountID, String date, int transactionNr, String username, String password, Account account) {
        this.amount = amount;
        this.accountID = accountID;
        this.date = date;
        TransactionNr = transactionNr;
        Username = username;
        this.password = password;
    }

    public Account() {
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public int getAccountID() {
        return accountID;
    }

    public void setAccountID(int accountID) {
        this.accountID = accountID;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public int getTransactionNr() {
        return TransactionNr;
    }

    public void setTransactionNr(int transactionNr) {
        TransactionNr = transactionNr;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        Username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }



}
