package com.example.applicationtier.controller;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.service.adminservice.AdminService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class AdminController {
    @Autowired
    private AdminService service;

    @PatchMapping("/validateCustomer")
    public ResponseEntity validateCustomer(@RequestBody Customer customer)  {
            boolean message = service.validateCustomer(customer);
            return new ResponseEntity<>(message, HttpStatus.OK);
    }

    @GetMapping("/getCustomers")
    public ResponseEntity getAllCustomers(){
        try {
            List<Customer> allCustomers = service.getAllCustomers();
            return new ResponseEntity<>(allCustomers, HttpStatus.OK);
        }
        catch(Exception e)
        {
            System.out.println(HttpStatus.NOT_FOUND);
            return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
        }
    }

    @GetMapping("/CreateAccount")
    public ResponseEntity createAccount(@RequestParam String username) {
        try {
            System.out.println("controller----->>>>>" + username);
            String message = service.createAccount(username);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }


    @DeleteMapping("/removeCustomer/{cprNumber}")
    public ResponseEntity removeCustomer(@PathVariable int cprNumber){
        try {
            String message = service.removeCustomer(cprNumber);
            System.out.println("controller-->>>>" + message);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
}
