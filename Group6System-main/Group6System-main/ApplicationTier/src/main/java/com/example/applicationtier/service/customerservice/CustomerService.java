package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;

public interface CustomerService {
    String registerCustomer(Customer newCustomer) throws Exception;
    String updateCustomer(Customer customer);
}
