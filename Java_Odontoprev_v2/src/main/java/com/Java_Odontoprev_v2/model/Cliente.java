package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.util.List;

@Data
@Builder
@Entity
@NoArgsConstructor
@AllArgsConstructor
@Setter
@Getter
@ToString
public class Cliente {

    @Id
    private String cpf_cnpj;

    private String cep;
    private String tipoPlano;

    @OneToOne(cascade = {CascadeType.PERSIST, CascadeType.REFRESH})
    private Usuario usuario;

    @OneToMany(fetch = FetchType.LAZY)
    private List<Consulta> consultas;
}
