package com.example.applicationtier.service.userservice;

import com.example.applicationtier.models.User;

public interface UserService {
    User validateUser(User user) throws Exception;
}
