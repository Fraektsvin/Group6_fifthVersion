package com.example.applicationtier.controller;

import com.example.applicationtier.models.User;
import com.example.applicationtier.service.userservice.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
public class UserController {

    @Autowired
    private UserService service;

    @PostMapping("/users")
    public ResponseEntity validateLogin(@RequestBody User user) {
        User toValidate = user;

        try {
            User returnObj = service.validateUser(toValidate);

            if (returnObj != null) return new ResponseEntity<>(returnObj, HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
        }
        return null;
    }

}
