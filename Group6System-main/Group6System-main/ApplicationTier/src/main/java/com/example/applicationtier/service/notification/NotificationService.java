package com.example.applicationtier.service.notification;

import com.example.applicationtier.models.Notification;

public interface NotificationService {
    Notification getNotification(String username) throws Exception;
    void sendNotificationToUser(String username, String message) throws Exception;
}
