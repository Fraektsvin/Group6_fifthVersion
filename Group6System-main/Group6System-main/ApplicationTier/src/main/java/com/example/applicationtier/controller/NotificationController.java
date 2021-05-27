package com.example.applicationtier.controller;

import com.example.applicationtier.models.Notification;
import com.example.applicationtier.service.notification.NotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
public class NotificationController {

    @Autowired
    NotificationService service;

    @GetMapping("/getNotification")
    public ResponseEntity getNotificationFromAdmin(@RequestParam String username) {
        try {
            System.out.println("requesting notification from" + username);
            Notification message = service.getNotification(username);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
    @GetMapping("/sendNotification")
    public ResponseEntity sendNotificationToUser(@RequestParam String username){
        try {
            System.out.println(username + " ////////////////////*******************");
            service.sendNotificationToUser(username);
            return new ResponseEntity<>("Successfully sent",HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity(HttpStatus.BAD_REQUEST);
        }
    }
}
