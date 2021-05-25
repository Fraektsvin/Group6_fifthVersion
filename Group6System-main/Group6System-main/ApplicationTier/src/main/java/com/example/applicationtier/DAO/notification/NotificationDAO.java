package com.example.applicationtier.DAO.notification;

import com.example.applicationtier.models.Notification;


public interface NotificationDAO {
    Notification getNotification(String username) throws Exception;
    Notification sendNotificationToUser(Notification toSend) throws Exception;
}
