package com.example.applicationtier.DAO.customer;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Repository;

@Repository
public interface CustomerDAO {
    Customer addCustomer(Customer customer) throws Exception;
    String updateCustomer(Customer customer);
    Customer getCustomer(String username);
    Customer getCustomer(int cprNumber);
}
