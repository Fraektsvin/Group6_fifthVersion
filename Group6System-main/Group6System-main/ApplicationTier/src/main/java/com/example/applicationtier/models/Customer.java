package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class Customer {
    @JsonProperty("name")
    private String name;

    @JsonProperty("cprnumber")
    private int cprNumber;

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

    @JsonProperty("customeraccount")
    private Account customerAccount;

    @JsonProperty("savedaccounts")
    private List<SavedAccounts> savedAccounts;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getCprNumber() {
        return cprNumber;
    }

    public void setCprNumber(int cprNumber) {
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

    public Account getCustomerAccount() {
        return customerAccount;
    }

    public void setCustomerAccount(Account customerAccount) {
        this.customerAccount = customerAccount;
    }

    public List<SavedAccounts> getSavedAccounts() {
        return savedAccounts;
    }

    public void setSavedAccounts(List<SavedAccounts> savedAccounts) {
        this.savedAccounts = savedAccounts;
    }

    @Override
    public String toString() {
        return "Customer{" +
                "name='" + name + '\'' +
                ", cprNumber=" + cprNumber +
                ", address='" + address + '\'' +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", email='" + email + '\'' +
                ", nationality='" + nationality + '\'' +
                ", countryOfResidence='" + countryOfResidence + '\'' +
                ", user=" + user +
                ", customerAccount=" + customerAccount +
                ", savedAccounts=" + savedAccounts +
                '}';
    }
}
