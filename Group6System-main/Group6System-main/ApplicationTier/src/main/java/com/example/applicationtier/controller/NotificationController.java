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
    public ResponseEntity getNotificationFromAdmin(@PathVariable String username) {
        try {
            Notification message = service.getNotification(username);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
    @PostMapping("/sendNotification")
    public ResponseEntity sendNotificationToUser(@RequestBody int cprNumber){
        try {
            System.out.println(cprNumber + " ////////////////////*******************");
            service.sendNotificationToUser(cprNumber);
            return new ResponseEntity<>(HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity(HttpStatus.BAD_REQUEST);
        }
    }
}
