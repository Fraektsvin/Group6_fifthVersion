package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.models.Customer;

import java.util.List;

public interface CustomerService {
    String registerCustomer(Customer newCustomer) ;
    void removeCustomer(int cprNumber);
    String updateCustomer(Customer customer);

    List<Customer> getAllCustomers();
}
