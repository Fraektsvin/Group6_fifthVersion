package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.DAO.transaction.TransactionDAO;
import com.example.applicationtier.models.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
public class TransactionServiceImpl implements TransactionService{
    @Qualifier("transactionDAO")
    @Autowired private TransactionDAO transDAO;

    @Override
    public String transferMoney(Transaction transaction) {
        String sendMoney = transDAO.transferMoney(transaction);

        if (transaction.getReceiver() != transDAO.getAccountNumber(transaction.getReceiver())) {
            return "Receiver account does not exist!";
        } else if ((transaction.getAmount()) <=
                (transDAO.checkBalance(transaction.getSender()) - transaction.getAmount())) {
            return "Insufficient founds!";
        }
        return sendMoney;
    }

    @Override
    public String payBill(Transaction transaction) {
        //String payBill = transDAO.payBill(transaction);
        return null;
    }
}
