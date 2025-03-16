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

    @OneToOne(cascade = {CascadeType.PERSIST, CascadeType.REFRESH})
    private Dentista dentista;

    @OneToOne(cascade = {CascadeType.PERSIST, CascadeType.REFRESH})
    private Cliente cliente;

}
