package com.Java_Odontoprev_v2;

import com.Java_Odontoprev_v2.model.Cliente;
import com.Java_Odontoprev_v2.model.Dentista;
import com.Java_Odontoprev_v2.model.Usuario;
import com.Java_Odontoprev_v2.repository.ClienteRepository;
import com.Java_Odontoprev_v2.repository.DentistaRepository;
import com.Java_Odontoprev_v2.repository.UsuarioRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDate;
import java.util.Random;

@SpringBootApplication
@RequiredArgsConstructor
public class JavaOdontoprevV2Application {

	public static void main(String[] args) {
		SpringApplication.run(JavaOdontoprevV2Application.class, args);
	}

	@Bean
	public CommandLineRunner Clientes(ClienteRepository clienteRepository,
															UsuarioRepository usuarioRepository) {
		return args -> {
			Random random = new Random();
			LocalDate dataAtual = LocalDate.now();

			for (int i = 0; i < 5; i++) { // Criando 5 clientes
				LocalDate dataNascimento = dataAtual.minusYears(18 + random.nextInt(60)); // Idades variadas

				Cliente clienteCadastrado = Cliente.builder()
						.usuario(Usuario.builder()
								.nome("Cliente " + (i + 1))
								.dataNascimento(dataNascimento)
								.Email("cliente" + (i + 1) + "@gmail.com")
								.Celular("(11)9" + String.format("%08d", random.nextInt(100000000)))
								.cpf_cnpj(String.format("%011d", random.nextInt(1000000000))) // CPF aleatório (simplificado)
								.build())
						.cep(String.format("%08d", random.nextInt(100000000)))
						.tipoPlano("Bem Estar White")
						.build();
				clienteRepository.save(clienteCadastrado);
			}
			System.out.println("Clientes criados com sucesso!");
		};
	}

	@Bean
	public CommandLineRunner Dentistas(DentistaRepository dentistaRepository,
															 UsuarioRepository usuarioRepository) {
		return args -> {
			Random random = new Random();
			LocalDate dataAtual = LocalDate.now();

			for (int i = 0; i < 3; i++) { // Criando 3 dentistas
				LocalDate dataNascimento = dataAtual.minusYears(25 + random.nextInt(45)); // Idades variadas

				Dentista dentistaCadastrado = Dentista.builder()
						.usuario(Usuario.builder()
								.nome("Dr(a). Dentista " + (i + 1))
								.dataNascimento(dataNascimento)
								.Email("dentista" + (i + 1) + "@odontoprev.com.br")
								.Celular("(11)9" + String.format("%08d", random.nextInt(100000000)))
								.cpf_cnpj(String.format("%011d", random.nextInt(1000000000))) // CPF aleatório (simplificado)
								.build())
						.cepClinica(String.format("%08d", random.nextInt(100000000)))
						.nomeClinica("Clínica " + (i + 1))
						.tipoClinica("Clínica Geral")
						.alvaraFuncionamento(true)
						.siteRedesSocial("@odontoprev")
						.build();
				dentistaRepository.save(dentistaCadastrado);
			}
			System.out.println("Dentistas criados com sucesso!");
		};
	}

}
