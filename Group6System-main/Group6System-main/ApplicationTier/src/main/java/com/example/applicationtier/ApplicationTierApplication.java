package com.example.applicationtier;

import com.example.applicationtier.DAO.Handler;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class ApplicationTierApplication  {

    public static void main(String[] args) {

        Handler handler = new Handler();
        new Thread(() -> handler.run()).start();

        SpringApplication.run(ApplicationTierApplication.class, args);
    }

}
