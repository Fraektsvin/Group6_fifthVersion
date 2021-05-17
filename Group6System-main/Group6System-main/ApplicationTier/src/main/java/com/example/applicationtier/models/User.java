package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;
import org.springframework.stereotype.Component;

@Component
public class User {
   public User(){}
    @JsonProperty("username")
    @JsonSetter
    private String username;
    @JsonProperty("password")
    @JsonSetter
    private String password;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "User{" +
                "username=" + username + '\'' +
                ", password=" + password +
                '}';
    }

}
