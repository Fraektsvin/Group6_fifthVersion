package com.example.applicationtier.models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;
@AllArgsConstructor
@NoArgsConstructor
@Data
@Component
public class Request {
    private String header;
    private Object obj;

    public Request(String header){
        this.header = header;
        obj = null;
    }
}
