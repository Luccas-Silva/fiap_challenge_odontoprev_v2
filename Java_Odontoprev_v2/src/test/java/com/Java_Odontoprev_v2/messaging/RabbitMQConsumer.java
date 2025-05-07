package com.Java_Odontoprev_v2.messaging;

import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;

@Service
public class RabbitMQConsumer {
    @RabbitListener(queues = "my_queue")
    public void listen(String message) {
        System.out.println("Received message from queue: " + message);
    }
}
