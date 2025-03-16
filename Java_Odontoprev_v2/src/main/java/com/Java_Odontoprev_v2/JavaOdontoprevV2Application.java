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

	@Bean
	public CommandLineRunner initialData(ClienteRepository clienteRepository, DentistaRepository dentistaRepository, ConsultaRepository consultaRepository) {
		return args -> {
			// Criando Usuários
			Usuario usuarioCliente1 = Usuario.builder()
					.nome("Cliente 1")
					.dataNascimento(LocalDate.of(1990, 1, 1))
					.Email("cliente1@email.com")
					.Celular("11999999991")
					.build();

			Usuario usuarioCliente2 = Usuario.builder()
					.nome("Cliente 2")
					.dataNascimento(LocalDate.of(1992, 2, 2))
					.Email("cliente2@email.com")
					.Celular("11999999992")
					.build();

			Usuario usuarioCliente3 = Usuario.builder()
					.nome("Cliente 3")
					.dataNascimento(LocalDate.of(1994, 3, 3))
					.Email("cliente3@email.com")
					.Celular("11999999993")
					.build();

			Usuario usuarioDentista1 = Usuario.builder()
					.nome("Dentista 1")
					.dataNascimento(LocalDate.of(1985, 4, 4))
					.Email("dentista1@email.com")
					.Celular("11999999994")
					.build();

			// Criando Clientes
			Cliente cliente1 = Cliente.builder()
					.cpf_cnpj("11111111111")
					.cep("01001000")
					.tipoPlano("Ouro")
					.usuario(usuarioCliente1)
					.build();

			Cliente cliente2 = Cliente.builder()
					.cpf_cnpj("22222222222")
					.cep("02002000")
					.tipoPlano("Prata")
					.usuario(usuarioCliente2)
					.build();

			Cliente cliente3 = Cliente.builder()
					.cpf_cnpj("33333333333")
					.cep("03003000")
					.tipoPlano("Bronze")
					.usuario(usuarioCliente3)
					.build();

			clienteRepository.saveAll(Arrays.asList(cliente1, cliente2, cliente3));

			// Criando Dentistas
			Dentista dentista1 = Dentista.builder()
					.cpf_cnpj("44444444444")
					.cepClinica("04004000")
					.nomeClinica("Clinica Sorriso")
					.tipoClinica("Geral")
					.alvaraFuncionamento(true)
					.siteRedesSocial("www.clinicasorriso.com.br")
					.usuario(usuarioDentista1)
					.build();

			dentistaRepository.save(dentista1);

			// Criando Consultas
			Consulta consulta1 = Consulta.builder()
					.dateConsulta(LocalDate.of(2023, 10, 20))
					.tipoConsulta("Limpeza")
					.valorMedioConsulta(150.0)
					.dentista(dentista1)
					.cliente(cliente1)
					.build();

			Consulta consulta2 = Consulta.builder()
					.dateConsulta(LocalDate.of(2023, 11, 15))
					.tipoConsulta("Canal")
					.valorMedioConsulta(400.0)
					.dentista(dentista1)
					.cliente(cliente2)
					.build();

			Consulta consulta3 = Consulta.builder()
					.dateConsulta(LocalDate.of(2023, 12, 10))
					.tipoConsulta("Extração")
					.valorMedioConsulta(200.0)
					.dentista(dentista1)
					.cliente(cliente3)
					.build();

			consultaRepository.saveAll(Arrays.asList(consulta1, consulta2, consulta3));
		};
	}

}
