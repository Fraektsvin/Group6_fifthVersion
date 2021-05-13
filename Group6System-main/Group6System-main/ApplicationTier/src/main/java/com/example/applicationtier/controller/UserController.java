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

    @GetMapping("/users")
    public ResponseEntity<User> validateLogin(@RequestParam String username, @RequestParam String password) {
        User toValidate = new User();
        toValidate.setUsername(username);
        toValidate.setPassword(password);

        System.out.println( "step 1 controller to service -->  " +  toValidate);
        User returnObj = service.validateUser(toValidate);

        if (returnObj != null) return new ResponseEntity<>(returnObj, HttpStatus.OK);
        else {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
    }

}
