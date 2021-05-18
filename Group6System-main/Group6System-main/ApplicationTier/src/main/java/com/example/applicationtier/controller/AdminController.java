package com.example.applicationtier.controller;

import com.example.applicationtier.models.Customer;
import com.example.applicationtier.service.adminservice.AdminService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class AdminController {
    @Autowired
    private AdminService service;

    @PostMapping("validateCustomer")
    public ResponseEntity validateCustomer(Customer customer){
        try {
            boolean message = service.validateCustomer(customer);
            System.out.println("Controller " + customer);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
    @GetMapping("/getCustomers")
    public ResponseEntity getAllCustomers(){
        try {
            List<Customer> allCustomers = service.getAllCustomers();
            System.out.println("Controller to service " + allCustomers);
            return new ResponseEntity<>(allCustomers, HttpStatus.OK);
        }
        catch(Exception e)
        {
            System.out.println(HttpStatus.NOT_FOUND);
            return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
        }
    }

    @DeleteMapping("/removeCustomer")
    public ResponseEntity deleteUser(@RequestHeader int cprNumber) {
        try {
            String message = service.removeCustomer(cprNumber);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }
}
