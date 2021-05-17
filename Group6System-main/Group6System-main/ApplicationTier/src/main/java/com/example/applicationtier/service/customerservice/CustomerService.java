package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.models.Customer;

public interface CustomerService {
    String registerCustomer(Customer newCustomer) ;
    void deleteCustomer(String username);
    void updateCustomer(Customer customer);
}
