package com.example.applicationtier.DAO.customer;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonSerializer;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class CustomerDAOImpl implements CustomerDAO{
    @Autowired
    private Handler handler;
    private final ObjectMapper objectMapper = new ObjectMapper();

    @Override
    public Customer registerCustomer(Customer customer) throws Exception {
        Request obj = new Request("AddCustomer", customer);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("CustomerAdded"))
        {
            Customer c = objectMapper.convertValue(response.getObj(), Customer.class);
            return c;
        }
        else throw new Exception((String) response.getObj());
    }

    @Override
    public String updateCustomer(Customer customer) {
        return null;
    }
    
    @Override
    public Customer getCustomer(String username) {
        Request obj = new Request("GetCustomer", username);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        if(newObj.getHeader().equals("GetCustomer")) {
            Customer customer = objectMapper.convertValue(newObj.getObj(), Customer.class);
            return customer;
        }
        return null;
    }

    @Override
    public Customer getCustomer(long cprNumber) {
        Request obj = new Request("GetCustomerWithCpr", cprNumber);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        if(newObj.getHeader().equals("GetCustomerWithCpr")) {
            Customer customer = objectMapper.convertValue(newObj.getObj(), Customer.class);
            return customer;
        }
        return null;
    }
}
