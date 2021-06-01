package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Transaction;

public interface TransactionService {
    String transferMoney(Transaction transaction) throws Exception;
    Account getAccount(String username) throws Exception;
    Account getAccount(String username, long accountNumber) throws Exception;
}
