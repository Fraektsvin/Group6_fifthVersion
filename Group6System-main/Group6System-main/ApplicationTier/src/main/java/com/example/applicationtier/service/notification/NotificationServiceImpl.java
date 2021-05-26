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
    @Autowired
    AdminDAO adminDAO;

    @Override
    public Notification getNotification(String username) throws Exception {
        return notificationDAO.getNotification(username);
    }

    @Override
    public void sendNotificationToUser(int cprNumber) throws Exception {
        Customer customer = null;

        List<Customer> customers = adminDAO.getAllCustomers();
        System.out.println("list found" + customers);
        for (Customer c: customers) {
            if(c.getCprNumber() == cprNumber)
            {
                customer = c;
                break;
            }
        }
        System.out.println("the customer is found" + customer);
        Notification toSend = new Notification();
        toSend.setMessage("Your request has been approved!");
        toSend.setCustomer(customer);
        System.out.println("notification ready to be sent to the customer" );

        System.out.println("notification send to" + customer.toString());

        notificationDAO.sendNotificationToUser(toSend);
    }
}
