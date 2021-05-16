package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

@Component
public class SavedAccounts {
    @JsonProperty("saveaccount")
    private Account saveAccount;
    @JsonProperty("accountname")
    private String accountName;
    @JsonProperty("amount")
    private double amount;

    public SavedAccounts(){};

    public Account getSaveAccount() {
        return saveAccount;
    }

    public double getAmount() {
        return amount;
    }

    public String getAccountName() {
        return accountName;
    }

    public void setAccountName(String accountName) {
        this.accountName = accountName;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public void setSaveAccount(Account saveAccount) {
        this.saveAccount = saveAccount;
    }

    @Override
    public String toString() {
        return "SavedAccounts{" +
                "saveAccount=" + saveAccount +
                ", accountName='" + accountName + '\'' +
                ", amount=" + amount +
                '}';
    }
}
