package com.example.applicationtier.controller;

import com.example.applicationtier.models.Customer;
import com.example.applicationtier.service.customerservice.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class CustomerController {
    @Autowired
    private CustomerService service;


    @PostMapping("/createNewCustomer")
    public ResponseEntity RegisterCustomer(@RequestBody Customer customer) {
        /*try {
            String successMessage = service.registerCustomer(customer);

            return new ResponseEntity<>(successMessage, HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
        }*/
        String returnMessage = service.registerCustomer(customer);

        return new ResponseEntity<>(returnMessage, HttpStatus.OK);
    }

    @PutMapping("/updateCustomer")
    public ResponseEntity updateUser(@RequestBody Customer customer){
        String message = service.updateCustomer(customer);
        return new ResponseEntity<>(message, HttpStatus.OK);
    }
}
