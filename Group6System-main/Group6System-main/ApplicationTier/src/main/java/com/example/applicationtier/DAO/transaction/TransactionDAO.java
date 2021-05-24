package com.example.applicationtier.DAO.transaction;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Transaction;


public interface TransactionDAO {
    Transaction transferMoney(Transaction transaction) throws Exception;
    String payBill(Transaction transaction);
    double getBalance(Account account);
}
