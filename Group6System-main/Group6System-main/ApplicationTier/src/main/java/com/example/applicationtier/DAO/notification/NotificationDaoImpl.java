package com.example.applicationtier.DAO.notification;

import com.example.applicationtier.DAO.Handler;
import com.example.applicationtier.models.Notification;
import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class NotificationDaoImpl implements NotificationDAO{
    @Autowired
    Handler handler;
    ObjectMapper mapper = new ObjectMapper();
    @Override
    public List<Notification> getNotification() throws Exception {
        Request obj = new Request("getNotification", null);
        handler.setObj(obj);

        Request response = handler.messageExchange(obj);
        if(response.getHeader().equals("getNotification")){
            return mapper.convertValue(response.getObj(), new TypeReference<>() {
            });
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
