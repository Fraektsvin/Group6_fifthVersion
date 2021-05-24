package com.example.applicationtier.DAO.transaction;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Account;
import com.example.applicationtier.models.Customer;
import com.example.applicationtier.models.Request;
import com.example.applicationtier.models.Transaction;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class TransactionDAOImpl implements TransactionDAO{
    @Autowired private Handler handler;
    private final ObjectMapper mapper = new ObjectMapper();
    @Override
    public String transferMoney(Transaction transaction) {
        Request obj = new Request("transferMoney", transaction);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("transferMoney")){
            return (String) response.getObj();
        }
        else return "Transfer FAIL!";
    }

    @Override
    public String payBill(Transaction transaction) {
        Request obj = new Request("payBill", transaction);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("payBill")){
            System.out.println("Inside dao response " + response.getObj());
            return (String) response.getObj();
        }
        else return "Payment could not complete!";
    }

    @Override
    public double getBalance(Account account) {
        Request obj = new Request("getBalance", account);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("getBalance")){
            return mapper.convertValue(response.getObj(), double.class);
        }
        else return 0;
    }
}
