package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.DAO.transaction.TransactionDAO;
import com.example.applicationtier.models.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TransactionServiceImpl implements TransactionService{
    @Autowired private TransactionDAO transDAO;

    @Override
    public String transferMoney(Transaction transaction) {
        if ((transaction.getReceiver() != transDAO.checkAccount(transaction.getReceiver())
                && (transaction.getSender() != transDAO.checkAccount(transaction.getSender())))) {
            return "Account does not exist!";
        } else if ((transaction.getAmount()) <=
                (transDAO.getBalance(transaction.getSender()) - transaction.getAmount())) {
            return "Insufficient funds.";
        } else {
            updateReceiver(transaction);
            updateSender(transaction);

            transDAO.transferMoney(transaction);

            return "Transaction completed.";
        }
    }

    private void updateReceiver(Transaction transaction) {
        double getReceiverBalance = transDAO.getBalance(transaction.getReceiver()) ;
        double newReceiverBalance = getReceiverBalance + transaction.getAmount();
        transaction.getReceiver().setBalance(newReceiverBalance);
        transDAO.updateBalance(transaction.getReceiver());
    }

    private void updateSender(Transaction transaction) {
        double getSenderBalance = transDAO.getBalance(transaction.getSender());
        double newSenderBalance = getSenderBalance - transaction.getAmount();
        transaction.getSender().setBalance(newSenderBalance);
        transDAO.updateBalance(transaction.getSender());
    }

    @Override
    public String payBill(Transaction transaction) {
        //String payBill = transDAO.payBill(transaction);
        return null;
    }
}
