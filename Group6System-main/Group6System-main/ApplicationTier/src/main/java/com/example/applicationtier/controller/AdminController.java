package com.example.applicationtier.controller;

import com.example.applicationtier.models.Customer;
import com.example.applicationtier.service.adminservice.AdminService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class AdminController {
    @Autowired
    private AdminService service;

    @GetMapping("/getCustomers")
    public ResponseEntity getAllCustomers(){
        List<Customer> allCustomers = service.getAllCustomers();
        return new ResponseEntity<>(allCustomers, HttpStatus.OK);
    }
    @DeleteMapping("/removeCustomer")
    public void deleteUser(@RequestHeader int cprNumber) {
        service.removeCustomer(cprNumber);
    }
}
