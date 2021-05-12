package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.DAO.customer.CustomerDAO;
import com.example.applicationtier.models.Customer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class CustomerServiceImpl implements CustomerService {

    @Autowired
    private CustomerDAO customerDAO;

    @Override
    public void registerCustomer(Customer newCustomer) {
            customerDAO.addCustomer(newCustomer);
    }

    @Override
    public void deleteCustomer(String username) {
        //firebaseService.deleteUser(username);
    }

    @Override
    public void updateCustomer(Customer customer) {
        //firebaseService.updateUserDetails(customer);
    }
}
