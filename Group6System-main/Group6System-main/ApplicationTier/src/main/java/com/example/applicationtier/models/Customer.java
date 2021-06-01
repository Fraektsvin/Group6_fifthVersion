package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

import java.util.List;


@Component
public class Customer {
    @JsonProperty("name")
    private String name;

    @JsonProperty("cprnumber")
    private long cprNumber;

    @JsonProperty("address")
    private Address address;

    @JsonProperty("phonenumber")
    private String phoneNumber;

    @JsonProperty("email")
    private String email;

    @JsonProperty("nationality")
    private String nationality;

    @JsonProperty("countryofresidence")
    private String countryOfResidence;

    @JsonProperty("user")
    private User user;

    @JsonProperty("isvalid")
    private boolean isValid;

    @JsonProperty("savedaccounts")
    private List<SavedAccounts> savedAccounts;

    public Customer() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public long getCprNumber() {
        return cprNumber;
    }

    public void setCprNumber(long cprNumber) {
        this.cprNumber = cprNumber;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getNationality() {
        return nationality;
    }

    public void setNationality(String nationality) {
        this.nationality = nationality;
    }

    public String getCountryOfResidence() {
        return countryOfResidence;
    }

    public void setCountryOfResidence(String countryOfResidence) {
        this.countryOfResidence = countryOfResidence;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public boolean isValid() {
        return isValid;
    }

    public void setValid(boolean valid) {
        isValid = valid;
    }

    public List<SavedAccounts> getSavedAccounts() {
        return savedAccounts;
    }

    public void setSavedAccounts(List<SavedAccounts> savedAccounts) {
        this.savedAccounts = savedAccounts;
    }
}
