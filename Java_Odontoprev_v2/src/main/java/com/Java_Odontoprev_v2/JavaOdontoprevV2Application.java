package com.Java_Odontoprev_v2;

import com.Java_Odontoprev_v2.model.Cliente;
import com.Java_Odontoprev_v2.model.Consulta;
import com.Java_Odontoprev_v2.model.Dentista;
import com.Java_Odontoprev_v2.model.Usuario;
import com.Java_Odontoprev_v2.repository.ClienteRepository;
import com.Java_Odontoprev_v2.repository.ConsultaRepository;
import com.Java_Odontoprev_v2.repository.DentistaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.annotation.Bean;
import org.springframework.context.event.EventListener;

import java.time.LocalDate;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

@SpringBootApplication
@RequiredArgsConstructor
public class JavaOdontoprevV2Application {

	public static void main(String[] args) {
		SpringApplication.run(JavaOdontoprevV2Application.class, args);
	}


}
