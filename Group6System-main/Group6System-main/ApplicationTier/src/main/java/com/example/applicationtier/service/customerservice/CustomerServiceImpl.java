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
       if(newCustomer.getCprNumber() >= 1000000000L && newCustomer.getCprNumber() <= 9999999999L) {
            Customer checkCustomer = customerDAO.getCustomer(newCustomer.getUser().getUsername());
            if (checkCustomer == null) {
                Customer checkCpr = customerDAO.getCustomer(newCustomer.getCprNumber());
                if (checkCpr == null) {
                    Customer c = customerDAO.registerCustomer(newCustomer);
                    return "Successfully registered!";
                }

                return "The Cpr Number is already registered!";
            }
            return "The username is already in use!";
        }
       return "Cpr number is not valid!";
    }

    @Override
    public String updateCustomer(Customer customer) {
        return null;
    }
}
