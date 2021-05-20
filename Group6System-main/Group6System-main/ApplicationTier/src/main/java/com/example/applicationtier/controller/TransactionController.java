package com.example.applicationtier.controller;

import com.example.applicationtier.models.Transaction;
import com.example.applicationtier.service.transactionservice.TransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TransactionController {
    @Autowired private TransactionService service;

    @PostMapping("/sendMoney")
    public ResponseEntity transferMoney(@RequestBody Transaction transaction){
        try {
            String message = service.transferMoney(transaction);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }

    @PostMapping("/payBill")
    public ResponseEntity payBills(@RequestBody Transaction transaction){
        try {
            String message = service.payBill(transaction);
            return new ResponseEntity<>(message, HttpStatus.OK);
        } catch (Exception exception) {
            return new ResponseEntity<>(exception.getMessage(), HttpStatus.NOT_FOUND);
        }
    }
}
