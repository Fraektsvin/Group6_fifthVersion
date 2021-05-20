package com.example.applicationtier.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;
@AllArgsConstructor
@NoArgsConstructor
@Data
@Component
public class User {
    @JsonProperty("username")
    @JsonSetter
    private String username;
    @JsonProperty("password")
    @JsonSetter
    private String password;
}
