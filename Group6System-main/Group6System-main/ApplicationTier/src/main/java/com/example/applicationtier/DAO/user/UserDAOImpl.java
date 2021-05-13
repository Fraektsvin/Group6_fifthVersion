package com.example.applicationtier.DAO.user;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Request;
import com.example.applicationtier.models.User;
import com.fasterxml.jackson.databind.JsonSerializable;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class UserDAOImpl implements UserDAO{

    @Autowired
    private Handler handler;

    @Override
    public User validateUser(User user) {

        Request login = new Request("CheckLogin", user);
        handler.setObj(login);

        Request response = handler.messageExchange(login);
        System.out.println("--> from the dao up to the service " + response);

        if(response.getHeader().equals("CheckLogin")) {
            System.out.println("Successfully logged in");

           /*
            ObjectMapper objectMapper = new ObjectMapper();
            User user1 = objectMapper.convertValue(response.getObj(),User.class);
            return user1;
            */
            return (User) login.getObj();
        }
        else
        {
            System.out.println("Login not successful");
            return null;
        }
    }
}
