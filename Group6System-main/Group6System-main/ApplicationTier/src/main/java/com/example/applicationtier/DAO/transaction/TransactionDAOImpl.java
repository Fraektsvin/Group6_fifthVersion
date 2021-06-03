package com.example.applicationtier.DAO.transaction;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Account;
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
    public Transaction transferMoney(Transaction transaction) throws Exception {
        Request obj = new Request("transferMoney", transaction);
        handler.setObj(obj);
        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("transferMoney")){
            return mapper.convertValue(response.getObj(), Transaction.class);
        }
        else throw new Exception((String) response.getObj());

    }
    @Override
    public Account getAccount(String username) throws Exception {
        Request obj = new Request("GetAccountWithUsername", username);
        handler.setObj(obj);

        Request accountObj = handler.messageExchange(obj);
        if(accountObj.getHeader().equals("AccountWithUsername")){
            return mapper.convertValue(accountObj.getObj(), Account.class);
        }
        throw new Exception((String) accountObj.getObj());
    }

}
