package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;

@Data
@Builder
@Entity
@NoArgsConstructor
@AllArgsConstructor
@Setter
@Getter
@ToString
public class Consulta {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String idConsulta;

    private LocalDate dateConsulta;
    private String tipoConsulta;
    private Double valorMedioConsulta;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "dentista_cpf_cnpj")
    private Dentista dentista;

    @ManyToOne(cascade = CascadeType.ALL) // Mudado para ManyToOne
    @JoinColumn(name = "cliente_cpf_cnpj")
    private Cliente cliente;

}
