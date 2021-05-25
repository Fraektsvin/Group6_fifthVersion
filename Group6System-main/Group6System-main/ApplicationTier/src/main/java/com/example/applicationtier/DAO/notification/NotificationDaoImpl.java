package com.example.applicationtier.DAO.notification;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class NotificationDaoImpl implements NotificationDAO{
    @Autowired
    Handler handler;
    ObjectMapper mapper = new ObjectMapper();
    @Override
    public Notification getNotification(String username) throws Exception {
        Request obj = new Request("getNotification", username);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("getNotification")){
            return mapper.convertValue(response.getObj(), Notification.class);
        }
        throw new Exception((String) response.getObj());
    }

    @Override
    public Notification sendNotificationToUser(Notification toSend) throws Exception {
        Request obj = new Request("sendNotificationToUser", toSend);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("sendNotificationToUser")){
            return mapper.convertValue(response.getObj(), Notification.class);
        }
        throw new Exception((String) response.getObj());
    }
}
