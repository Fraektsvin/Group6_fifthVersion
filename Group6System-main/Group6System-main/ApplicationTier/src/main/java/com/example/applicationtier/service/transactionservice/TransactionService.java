package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.models.Transaction;


public interface TransactionService {
    String transferMoney(Transaction transaction);
    String payBill(Transaction transaction);
}
