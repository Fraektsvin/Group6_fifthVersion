package com.example.applicationtier.DAO.user;

import com.example.applicationtier.models.User;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

@Repository
public interface UserDAO {
    User validateUser(User user) throws Exception;
}
