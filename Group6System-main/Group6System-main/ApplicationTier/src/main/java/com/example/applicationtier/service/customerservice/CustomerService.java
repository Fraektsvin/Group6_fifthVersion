package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.models.Customer;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface CustomerService {
    String registerCustomer(Customer newCustomer) ;
    String updateCustomer(Customer customer);
}
