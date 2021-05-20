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
public class SavedAccounts {
    @JsonProperty("saveaccount")
    private Account saveAccount;
    @JsonProperty("accountname")
    private String accountName;
    @JsonProperty("amount")
    private double amount;
}
