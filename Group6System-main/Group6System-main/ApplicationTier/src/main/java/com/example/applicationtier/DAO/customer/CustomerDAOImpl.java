package com.example.applicationtier.DAO.customer;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Request;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class CustomerDAOImpl implements CustomerDAO{
    @Autowired
    private Handler handler;

    @Override
    public void addCustomer(Customer customer) {
        Request obj = new Request("AddCustomer", customer);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        System.out.println(response.getObj());
    }

    @Override
    public Customer getUser(String username) {
        Request obj = new Request("GetCustomer", username);
        handler.setObj(obj);

        Request newObj = handler.messageExchange(obj);
        return (Customer) newObj.getObj();
    }


}
