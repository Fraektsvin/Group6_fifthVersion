package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.models.Transaction;
import org.springframework.stereotype.Service;



public interface TransactionService {
    String transferMoney(Transaction transaction) throws Exception;
    String payBill(Transaction transaction);
}
