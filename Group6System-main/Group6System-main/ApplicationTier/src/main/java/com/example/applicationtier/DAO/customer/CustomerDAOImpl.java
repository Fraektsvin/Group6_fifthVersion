package com.example.applicationtier.DAO.customer;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.databind.JsonSerializer;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class CustomerDAOImpl implements CustomerDAO{
    @Autowired
    private Handler handler;
    private ObjectMapper objectMapper = new ObjectMapper();

    @Override
    public void addCustomer(Customer customer) {
        Request obj = new Request("AddCustomer", customer);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        System.out.println(response.getObj());
    }

    @Override
    public Customer getCustomer(String username) {
        Request obj = new Request("GetCustomer", username);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        if(newObj.getHeader().equals("GetCustomer")) {
            System.out.println(newObj.getObj() + " from dao impl");
            Customer customer = objectMapper.convertValue(newObj.getObj(), Customer.class);
            return customer;
        }
        return null;
    }

    @Override
    public Customer getCustomer(int cprnumber) {
        Request obj = new Request("GetCustomerWithCpr", cprnumber);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        if(newObj.getHeader().equals("GetCustomerWithCpr")) {
            System.out.println(newObj.getObj() + " from dao impl");
            Customer customer = objectMapper.convertValue(newObj.getObj(), Customer.class);
            return customer;
        }
        return null;
    }
}
