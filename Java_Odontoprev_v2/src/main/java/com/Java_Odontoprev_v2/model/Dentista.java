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
public class Dentista {

    @Id
    private String cpf_cnpj;

    private String cepClinica;
    private String nomeClinica;
    private String tipoClinica;
    private boolean alvaraFuncionamento;
    private String siteRedesSocial;

    @OneToOne(cascade = CascadeType.ALL)
    private Usuario usuario;

    @OneToMany(mappedBy = "dentista", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<Consulta> consultas;

}
