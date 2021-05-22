package com.example.applicationtier.DAO.transaction;

import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Transaction;
import org.springframework.stereotype.Repository;


public interface TransactionDAO {
    String transferMoney(Transaction transaction);
    String payBill(Transaction transaction);
    double checkBalance(Customer customer);
    Account getAccountNumber(Account account);
}
