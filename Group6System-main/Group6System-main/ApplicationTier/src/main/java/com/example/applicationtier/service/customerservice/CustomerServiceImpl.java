package com.example.applicationtier.service.customerservice;

import com.example.applicationtier.DAO.customer.CustomerDAO;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class CustomerServiceImpl implements CustomerService {

    @Autowired
    private CustomerDAO customerDAO;

    @Override
    public String registerCustomer(Customer newCustomer) throws Exception {
        Customer checkCustomer = customerDAO.getCustomer(newCustomer.getUser().getUsername());
        System.out.println(checkCustomer + " from service");
        if(checkCustomer == null)
        {
            Customer checkCpr = customerDAO.getCustomer(newCustomer.getCprNumber());
            if(checkCpr == null) {
                Customer c = customerDAO.addCustomer(newCustomer);
                System.out.println("Successfully registered!");
                return "Successfully registered!";
            }

            System.out.println("The Cpr Number is already registered!");
            return "The Cpr Number is already registered!";
        }

        System.out.println("The username is already in use!");
        return "The username is already in use!";
    }

    @Override
    public String updateCustomer(Customer customer) {
        return null;
    }

    @Override
    public Account getAccount(String username) throws Exception {
        Account account = customerDAO.getAccount(username);

        return account;
    }
}
