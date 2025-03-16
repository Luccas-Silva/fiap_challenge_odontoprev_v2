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
public class Usuario {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String idUsuario;

    private String nome;
    private LocalDate dataNascimento;
    private String Email;
    private String Celular;
}
