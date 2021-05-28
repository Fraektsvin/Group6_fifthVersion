package com.example.applicationtier.service.notification;
import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.DAO.notification.NotificationDAO;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class NotificationServiceImpl implements NotificationService {
    @Autowired
    NotificationDAO notificationDAO;
    @Autowired
    AdminDAO adminDAO;

    @Override
    public List<Notification> getNotification(String username) throws Exception {
       List<Notification> notifications = notificationDAO.getNotification();

        List<Notification> requiredForUser = new ArrayList<>();

        for (Notification n : notifications)
        {
            if (n.getUser().getUsername().equals(username))
            {
                requiredForUser.add(n);
            }
        }
        return requiredForUser;
    }

    @Override
    public void sendNotificationToUser(String username, String message) throws Exception {
        User user = adminDAO.checkUser(username);

        Notification toSend = new Notification();
        toSend.setMessage(message);
        toSend.setUser(user);

        notificationDAO.sendNotificationToUser(toSend);
    }
}
