package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.DAO.transaction.TransactionDAO;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TransactionServiceImpl implements TransactionService{
    @Autowired private TransactionDAO transDAO;

    @Override
    public String transferMoney(Transaction transaction) throws Exception{

        double checkBalance = transaction.getSender().getBalance() - transaction.getAmount();
        System.out.println(checkBalance);
        if (checkBalance < 0) {
            return "Insufficient funds.";
        } else
        {
            updateReceiver(transaction);

            updateSender(transaction);

            transDAO.transferMoney(transaction);

            return "Transaction completed.";
        }
    }

    private void updateReceiver(Transaction transaction) {
        double getReceiverBalance = transaction.getReceiver().getBalance();
        double newReceiverBalance = getReceiverBalance + transaction.getAmount();
        transaction.getReceiver().setBalance(newReceiverBalance);
    }

    private void updateSender(Transaction transaction) {
        double getSenderBalance = transaction.getSender().getBalance();
        double newSenderBalance = getSenderBalance - transaction.getAmount();
        transaction.getSender().setBalance(newSenderBalance);
    }

    public Account getAccount(String username) throws Exception {
        Account account = transDAO.getAccount(username);
        return account;
    }

    @Override
    public String payBill(Transaction transaction) {
        //String payBill = transDAO.payBill(transaction);
        return null;
    }
}
