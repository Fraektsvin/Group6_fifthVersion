package com.example.applicationtier.DAO.user;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Request;
import com.example.applicationtier.models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class UserDAOImpl implements UserDAO{

    @Autowired
    private Handler handler;

    @Override
    public User validateUser(User user) throws Exception{

        Request login = new Request("CheckLogin", user);
        handler.setObj(login);

        Request response = handler.messageExchange(login);

        if(response.getHeader().equals("CheckLogin")) {
            return (User) login.getObj();
        }
        else throw new Exception((String) response.getObj());
    }
}
