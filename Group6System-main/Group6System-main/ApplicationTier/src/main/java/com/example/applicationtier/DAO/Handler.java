package com.example.applicationtier.DAO;

import com.example.applicationtier.models.Request;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

@Component
public class Handler implements Runnable {
    private InputStream input;
    private OutputStream output;
    private Socket socket;
    private ObjectMapper objectMapper;
    private Request obj;

    public Handler()
    {
        try {
            socket = new Socket("127.0.0.1", 9999);
            output = socket.getOutputStream();
            input = socket.getInputStream();
            objectMapper = new ObjectMapper();
            obj = new Request();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void setObj(Request obj) {
        this.obj = obj;
    }

    @Override
    public void run() {
           /* while(true)
            {
                if(!(obj.getObj().equals("Close connection"))){
                    messageExchange(obj);
                }
                else{
                    break;
                }
            }*/
    }

    public Request messageExchange(Request objToSend){
        byte[] toClient;
        byte[] dataFromClient = new byte[8000];

        //Sending an object
        try {
            toClient = objectMapper.writeValueAsBytes(objToSend);
            output.write(toClient,0,toClient.length);
            System.out.println("step 4 --> handler send to db socket " + objToSend);
        } catch (IOException ioException) {
            throw new RuntimeException(ioException.getMessage());
        }

        try
        {
            //Reading a return message
            int bytesRead = input.read(dataFromClient, 0, dataFromClient.length);
            String readObj = new String(dataFromClient);
            Request finalObj = objectMapper.readValue(readObj, Request.class);
            System.out.println("back from the db to the handler --> " + readObj);
            return finalObj; }
        catch (IOException e) {
            throw new RuntimeException(e.getMessage());
        }
    }
}
