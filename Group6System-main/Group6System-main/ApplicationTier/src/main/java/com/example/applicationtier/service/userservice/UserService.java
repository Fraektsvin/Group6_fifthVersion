package com.example.applicationtier.service.userservice;

import com.example.applicationtier.models.User;
import org.springframework.stereotype.Service;

@Service
public interface UserService {
    User validateUser(User user) throws Exception;
}
