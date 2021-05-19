package com.example.applicationtier.DAO.admin;

import com.example.applicationtier.DAO.Handler;
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
    private final ObjectMapper mapper = new ObjectMapper();

    @Override
    public boolean validateCustomer(Customer customer) {
        Request obj = new Request("IsValid", customer);
        System.out.println("In Dao to db " + obj);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        System.out.println("response to adminDAO" + response.getObj());
        Customer customer1 = mapper.convertValue(response.getObj(), Customer.class);
        return customer1.isValid();
    }

    @Override
    public List<Customer> getAllCustomers() {
        Request obj = new Request("GetAllCustomers");
        handler.setObj(obj);
        System.out.println("Inside dao " + obj);

        Request response = handler.messageExchange(obj);
        return mapper.convertValue(response.getObj(),
                new TypeReference<>() {
                });
    }

    @Override
    public String removeCustomer(int cprNumber) {
        return null;
    }

}
