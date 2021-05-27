package com.example.applicationtier.DAO.admin;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.User;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface AdminDAO {
    boolean validateCustomer(Customer customer);
    List<Customer> getAllCustomers() throws Exception;
    String removeCustomer(int cprNumber);
    Account CreateAccount(Account account) throws Exception;
    long getLastAccountNumber() throws Exception;
    User checkUser(String username) throws Exception;
}
