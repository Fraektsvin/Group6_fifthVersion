package com.example.applicationtier.service.userservice;

import com.example.applicationtier.DAO.user.UserDAO;
import com.example.applicationtier.models.User;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
@Service
public class UserServiceImpl implements UserService{

    @Autowired
    private UserDAO userDAO;

    public UserServiceImpl(UserDAO userDAO) {
        this.userDAO = userDAO;
    }

    @Override
    public User validateUser(User user) throws Exception {
        User loginUser = userDAO.validateUser(user);
        System.out.println(" step 2 --> from the service to dao " + user);
        if (loginUser != null) {
            return loginUser;
        }
        return null;
    }
}
