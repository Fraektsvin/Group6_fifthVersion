package com.example.applicationtier.controller;

import com.example.applicationtier.models.User;
import com.example.applicationtier.service.userservice.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class UserController {

    @Autowired
    private UserService service;

    @GetMapping("/users")
    public User validateLogin(@RequestParam String username, @RequestParam String password) {
        User toValidate = new User(username, password);
        System.out.println( "step 1 controller to service -->  " +  toValidate);
        User returnObj = service.validateUser(toValidate);
        return returnObj;
    }

}
