package com.example.applicationtier.controller;

import com.example.applicationtier.models.Notification;
import com.example.applicationtier.service.notification.NotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class NotificationController {

    @Autowired
    NotificationService service;

    @GetMapping("/getNotification")
    public ResponseEntity getNotificationFromAdmin(@RequestParam String username) {
        try {
            List<Notification> notifications = service.getNotification(username);
            return new ResponseEntity<>(notifications, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
}
