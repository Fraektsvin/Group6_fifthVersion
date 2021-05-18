package com.example.applicationtier.service.adminservice;

import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface AdminService {
    boolean validateCustomer(Customer customer);
    List<Customer> getAllCustomers();
    String removeCustomer(int cprNumber);
}
