package com.example.applicationtier.service.notification;
import com.example.applicationtier.DAO.admin.AdminDAO;
import com.example.applicationtier.DAO.notification.NotificationDAO;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Notification;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class NotificationServiceImpl implements NotificationService {
    @Autowired
    NotificationDAO notificationDAO;
    AdminDAO adminDAO;
    @Override
    public Notification getNotification(String username) throws Exception {
        return notificationDAO.getNotification(username);
    }

    @Override
    public void sendNotificationToUser(int cprnumber) throws Exception {
        Customer customer = null;

        List<Customer> customers = adminDAO.getAllCustomers();
        for (Customer c: customers) {
            if(c.getCprNumber() == cprnumber)
            {
                customer = c;
                break;
            }
        }

        Notification toSend = new Notification();
        toSend.setMessage("Your request has been approved!");
        toSend.setCustomer(customer);

        notificationDAO.sendNotificationToUser(toSend);
    }
}
