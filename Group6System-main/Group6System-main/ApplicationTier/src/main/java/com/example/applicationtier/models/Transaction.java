package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

import java.util.Date;

@Component
public class Transaction {
    @JsonProperty("sender")
    private Account sender;
    @JsonProperty("receiver")
    private Account receiver;
    @JsonProperty("amount")
    private double amount;
    @JsonProperty("message")
    private String message;
    @JsonProperty("date")
    private Date date;
    @JsonProperty("save")
    private boolean save;

    public Transaction() {
    }

    public Account getSender() {
        return sender;
    }

    public void setSender(Account sender) {
        this.sender = sender;
    }

    public Account getReceiver() {
        return receiver;
    }

    public void setReceiver(Account receiver) {
        this.receiver = receiver;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public boolean isSave() {
        return save;
    }

    public void setSave(boolean save) {
        this.save = save;
    }

}
