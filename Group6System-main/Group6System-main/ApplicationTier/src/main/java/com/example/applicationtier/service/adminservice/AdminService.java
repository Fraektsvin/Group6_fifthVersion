package com.example.applicationtier.service.adminservice;

import com.example.applicationtier.models.Customer;
import java.util.List;

public interface AdminService {
    boolean validateCustomer(Customer customer);
    List<Customer> getAllCustomers() throws Exception;
    String removeCustomer(int cprNumber);

    String CreateAccount(int cprNumber) throws Exception;
}
