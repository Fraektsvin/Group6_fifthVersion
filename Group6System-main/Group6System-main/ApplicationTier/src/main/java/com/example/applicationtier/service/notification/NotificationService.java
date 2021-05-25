package com.example.applicationtier.service.notification;

import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.User;

public interface NotificationService {
    Notification getNotification(String username) throws Exception;
    void sendNotificationToUser(int cprnumber) throws Exception;
}
