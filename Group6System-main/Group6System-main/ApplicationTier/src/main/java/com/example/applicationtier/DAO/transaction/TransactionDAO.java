package com.example.applicationtier.DAO.transaction;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Transaction;


public interface TransactionDAO {
    String transferMoney(Transaction transaction);
    String payBill(Transaction transaction);
    double getBalance(Account account);
    Account checkAccount(Account account);
    double updateBalance(Account balance);
}
