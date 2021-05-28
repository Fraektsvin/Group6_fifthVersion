package com.example.applicationtier.DAO.notification;

import com.example.applicationtier.models.Notification;

import java.util.List;


public interface NotificationDAO {
    List<Notification> getNotification() throws Exception;
    Notification sendNotificationToUser(Notification toSend) throws Exception; 
}
