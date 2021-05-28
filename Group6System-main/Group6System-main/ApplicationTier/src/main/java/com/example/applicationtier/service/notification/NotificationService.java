package com.example.applicationtier.service.notification;

import com.example.applicationtier.models.Notification;

import java.awt.event.ItemListener;
import java.util.List;

public interface NotificationService {
    List<Notification> getNotification(String username) throws Exception;
    void sendNotificationToUser(String username, String message) throws Exception;
}
