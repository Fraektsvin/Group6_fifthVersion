package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;

import java.util.Date;
@AllArgsConstructor
@NoArgsConstructor
@Data
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
}
