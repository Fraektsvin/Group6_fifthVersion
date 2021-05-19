package com.example.applicationtier.service.adminservice;

import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.List;

@Service
public class AdminServiceImpl implements AdminService{
    @Autowired
    private AdminDAO adminDAO;

    @Override
    public boolean validateCustomer(Customer customer) {
        boolean customerToValidate = adminDAO.validateCustomer(customer);
        System.out.println("Service to DAO " + customerToValidate);
        return customerToValidate;
    }

    @Override
    public List<Customer> getAllCustomers() throws Exception {
        List<Customer> getAll = adminDAO.getAllCustomers();
        System.out.println("Inside service" + getAll);
        if(!getAll.isEmpty()){
            return getAll;
        }
        throw new Exception("No customers to show!");
    }

    @Override
    public String removeCustomer(int cprNumber) {
        String customerToRemove = adminDAO.removeCustomer(cprNumber);
        if(!customerToRemove.isEmpty()){
            return customerToRemove;
        }
        return "Cpr-Number not found!";
    }

    @Override
    public String CreateAccount(int cprNumber) throws Exception {
        Customer customer = null;

        List<Customer> customers = adminDAO.getAllCustomers();
        for (Customer c: customers) {
            if(c.getCprNumber() == cprNumber)
            {
                customer = c;
                break;
            }
        }

        //System.out.println(customer);

        Account account = new Account(10000.00, accountNumberGenerator(), new Date(System.currentTimeMillis()));
        System.out.println(account);
        account.setCustomer(customer);


        String message = adminDAO.CreateAccount(account, cprNumber);
        return message;
    }

    private long accountNumberGenerator() throws Exception {
        long lastAccountNumber = adminDAO.getLastAccountNumber();
        long available = lastAccountNumber + 1;
        return available;
    }
}
