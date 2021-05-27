package com.example.applicationtier.service.notification;
import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.DAO.notification.NotificationDAO;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class NotificationServiceImpl implements NotificationService {
    @Autowired
    NotificationDAO notificationDAO;
    @Autowired
    AdminDAO adminDAO;

    @Override
    public Notification getNotification(String username) throws Exception {
        return notificationDAO.getNotification(username);
    }

    @Override
    public void sendNotificationToUser(String username) throws Exception {
        User user = adminDAO.checkUser(username);


        System.out.println("the customer is found" + user);
        Notification toSend = new Notification();
        toSend.setMessage("Request Approved :)");
        toSend.setUser(user);
        System.out.println("notification ready to be sent to the customer" );

        System.out.println("notification send to" + user.toString());

        notificationDAO.sendNotificationToUser(toSend);
    }
}
