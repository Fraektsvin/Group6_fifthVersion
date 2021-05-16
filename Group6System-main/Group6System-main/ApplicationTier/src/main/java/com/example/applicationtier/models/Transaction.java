package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

import java.util.Date;

@Component
public class Transaction {

    @JsonProperty("sender")
    private Customer sender;
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


    public void setSender(Customer sender) {
        this.sender = sender;
    }

    public Customer getSender() {
        return sender;
    }

    public void setReceiver(Account receiver) {
        this.receiver = receiver;
    }

    public Account getReceiver() {
        return receiver;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public double getAmount() {
        return amount;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Date getDate() {
        return date;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getMessage() {
        return message;
    }

    public void setSave(boolean save) {
        this.save = save;
    }

    public boolean isSave() {
        return save;
    }

    @Override
    public String toString() {
        return "Transaction{" +
                "sender=" + sender +
                ", receiver=" + receiver +
                ", amount=" + amount +
                ", message='" + message + '\'' +
                ", date=" + date +
                ", save=" + save +
                '}';
    }
}
