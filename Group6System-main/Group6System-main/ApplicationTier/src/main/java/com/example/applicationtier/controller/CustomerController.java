package com.example.applicationtier.controller;

import com.example.applicationtier.models.Customer;
import com.example.applicationtier.service.customerservice.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class CustomerController {
    @Autowired
    private CustomerService service;

    @PostMapping("/createNewCustomer")
    public void  RegisterCustomer(@RequestBody Customer customer) {
        service.registerCustomer(customer);
    }

    @DeleteMapping("/deleteCustomer")
    public void deleteUser(@RequestHeader String name) {
        service.deleteCustomer(name);
    }

    @PutMapping("/updateCustomer")
    public void updateUser(@RequestBody Customer customer){
        service.updateCustomer(customer);
    }
}
