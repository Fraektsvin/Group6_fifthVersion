package com.example.applicationtier.service.adminservice;

import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.User;
import com.example.applicationtier.service.notification.NotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.util.List;

@Service
public class AdminServiceImpl implements AdminService{
    @Autowired
    private AdminDAO adminDAO;
    @Autowired
    private NotificationService notificationService;

    @Override
    public boolean validateCustomer(Customer customer) {
        boolean customerToValidate = adminDAO.validateCustomer(customer);
        return customerToValidate;
    }

    @Override
    public List<Customer> getAllCustomers() throws Exception {
        List<Customer> getAll = adminDAO.getAllCustomers();
        return getAll;
    }

    @Override
    public String removeCustomer(int cprNumber){
        String customerToRemove = adminDAO.removeCustomer(cprNumber);
        return customerToRemove;
    }

    @Override
    public String createAccount(String username) throws Exception {
        User toFind = adminDAO.checkUser(username);

        Date d = new Date(System.currentTimeMillis());
        String date = d.toString();
        Account account = new Account();
        account.setAccountNumber(accountNumberGenerator());
        account.setDate(date);
        account.setBalance(10000.00);
        account.setUser(toFind);

        Account acc = adminDAO.createAccount(account);

        if(acc != null){
            notificationService.sendNotificationToUser(username, "Request Approved :)");
            return "Successful!!";
        }
        else return "Not Successful!!!!!";
    }

    private long accountNumberGenerator(){
        try {
            long lastAccountNumber = adminDAO.getLastAccountNumber();
            long available = lastAccountNumber + 1;
            return available;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return 0;
    }
}
