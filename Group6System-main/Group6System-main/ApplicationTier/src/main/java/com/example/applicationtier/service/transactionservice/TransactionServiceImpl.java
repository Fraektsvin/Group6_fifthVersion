package com.example.applicationtier.service.transactionservice;

import com.example.applicationtier.DAO.transaction.TransactionDAO;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.Transaction;
import com.example.applicationtier.service.notification.NotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TransactionServiceImpl implements TransactionService{
    @Autowired private TransactionDAO transDAO;
    @Autowired private NotificationService notificationService;

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

    private void updateReceiver(Transaction transaction) throws Exception {
        double getReceiverBalance = transaction.getReceiver().getBalance();
        double newReceiverBalance = getReceiverBalance + transaction.getAmount();
        transaction.getReceiver().setBalance(newReceiverBalance);
        notificationService.sendNotificationToUser(transaction.getReceiver().getUser().getUsername(),
                transaction.getAmount() + "kr received from " +
                transaction.getSender().getUser().getUsername() + " Message: " + transaction.getMessage());
    }

    private void updateSender(Transaction transaction) throws Exception {
        double getSenderBalance = transaction.getSender().getBalance();
        double newSenderBalance = getSenderBalance - transaction.getAmount();
        transaction.getSender().setBalance(newSenderBalance);
        notificationService.sendNotificationToUser(transaction.getSender().getUser().getUsername(),
                transaction.getAmount() + "kr transfered to " +
                transaction.getReceiver().getUser().getUsername() + " Message: " + transaction.getMessage());

    }

    public Account getAccount(String username) throws Exception {
        Account account = transDAO.getAccount(username);
        return account;
    }

    @Override
    public Account getAccount(String username, long accountNumber) throws Exception {
        Account account = getAccount(username);
        if(account.getAccountNumber() == accountNumber){
            return account;
        }
        throw new Exception("Username and Account number didn't match");
    }
}
