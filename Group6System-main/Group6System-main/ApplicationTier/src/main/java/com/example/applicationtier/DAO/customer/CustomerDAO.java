package com.example.applicationtier.DAO.customer;

import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Repository;

@Repository
public interface CustomerDAO {
    void addCustomer(Customer customer);
    String updateCustomer(Customer customer);
    Customer getCustomer(String username);
    Customer getCustomer(int cprNumber);
}
