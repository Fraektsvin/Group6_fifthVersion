package com.example.applicationtier.DAO.customer;


import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Component;

@Component
public interface CustomerDAO {
    void addCustomer(Customer customer);
    Customer getUser(String username);
}
