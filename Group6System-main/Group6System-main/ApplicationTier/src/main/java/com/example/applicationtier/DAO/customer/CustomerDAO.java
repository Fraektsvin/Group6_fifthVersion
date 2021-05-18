package com.example.applicationtier.DAO.customer;


import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public interface CustomerDAO {
    void addCustomer(Customer customer);
    Customer getCustomer(String username);
    Customer getCustomer(int cprNumber);
    List<Customer> getAllCustomers();
}
