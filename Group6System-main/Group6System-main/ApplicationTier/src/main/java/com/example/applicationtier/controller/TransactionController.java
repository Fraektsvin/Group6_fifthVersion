package com.example.applicationtier.controller;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Transaction;
import com.example.applicationtier.service.transactionservice.TransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

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

    @GetMapping("/getAccount")
    public ResponseEntity getAccount(@RequestParam String username){
        try {
            Account account = service.getAccount(username);
            return new ResponseEntity<>(account, HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
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
