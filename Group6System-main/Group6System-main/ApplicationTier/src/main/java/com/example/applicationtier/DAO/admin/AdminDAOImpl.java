package com.example.applicationtier.DAO.admin;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class AdminDAOImpl implements AdminDAO {
    @Autowired
    private Handler handler;
    private ObjectMapper mapper = new ObjectMapper();
    @Override
    public boolean validateCustomer(Customer customer) {
        Request obj = new Request("isValid", customer);
        handler.setObj(obj);

        Request response;
        return false;
    }

    @Override
    public List<Customer> getAllCustomers() {
        Request obj = new Request("GetAllCustomers");
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        List<Customer> customers = mapper.convertValue(response.getObj(),
                new TypeReference<List<Customer>>() {
                });
        return customers;
    }

    @Override
    public String removeCustomer(int cprNumber) {
        return null;
    }

}
