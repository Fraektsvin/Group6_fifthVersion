package com.example.applicationtier.service.adminservice;

import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.models.Customer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AdminServiceImpl implements AdminService{
    @Autowired
    private AdminDAO adminDAO;

    @Override
    public boolean validateCustomer(Customer customer) throws Exception {
        boolean customerToValidate = adminDAO.validateCustomer(customer);
        System.out.println("Service to DAO " + customerToValidate);
        if(!customerToValidate){
            return true;
        }
       throw new Exception("Not found!");
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
}
