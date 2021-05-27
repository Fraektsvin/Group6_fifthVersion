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

    @JsonProperty("user")
    private User user;

  /* @JsonProperty("transactions")
    private List<Transaction> transactions;*/


   /* public List<Transaction> getTransactions() {
        return transactions;
    }

    public void setTransactions(List<Transaction> transactions) {
        this.transactions = transactions;
    }
*/

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
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

    public double getBalance() {
        return balance;
    }

    @Override
    public String toString() {
        return "Account{" +
                "balance=" + balance +
                ", accountNumber=" + accountNumber +
                ", date='" + date + '\'' +
                ", user=" + user +
                '}';
    }

    public long getAccountNumber() {
        return accountNumber;
    }
}
