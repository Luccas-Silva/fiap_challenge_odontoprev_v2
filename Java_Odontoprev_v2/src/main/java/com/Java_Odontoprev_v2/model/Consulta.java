package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;
import java.util.Objects;

@Entity
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

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "cliente_cpf_cnpj")
    private Cliente cliente;

    public Consulta() {
    }
    public Consulta(String idConsulta, LocalDate dateConsulta, String tipoConsulta, Double valorMedioConsulta, Dentista dentista, Cliente cliente) {
        this.idConsulta = idConsulta;
        this.dateConsulta = dateConsulta;
        this.tipoConsulta = tipoConsulta;
        this.valorMedioConsulta = valorMedioConsulta;
        this.dentista = dentista;
        this.cliente = cliente;
    }

    public String getIdConsulta() {
        return idConsulta;
    }
    public void setIdConsulta(String idConsulta) {
        this.idConsulta = idConsulta;
    }

    public LocalDate getDateConsulta() {
        return dateConsulta;
    }
    public void setDateConsulta(LocalDate dateConsulta) {
        this.dateConsulta = dateConsulta;
    }

    public String getTipoConsulta() {
        return tipoConsulta;
    }
    public void setTipoConsulta(String tipoConsulta) {
        this.tipoConsulta = tipoConsulta;
    }

    public Double getValorMedioConsulta() {
        return valorMedioConsulta;
    }
    public void setValorMedioConsulta(Double valorMedioConsulta) {
        this.valorMedioConsulta = valorMedioConsulta;
    }

    public Dentista getDentista() {
        return dentista;
    }
    public void setDentista(Dentista dentista) {
        this.dentista = dentista;
    }

    public Cliente getCliente() {
        return cliente;
    }
    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Consulta consulta = (Consulta) o;
        return Objects.equals(idConsulta, consulta.idConsulta);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idConsulta);
    }

    @Override
    public String toString() {
        return "Consulta{" +
                "idConsulta='" + idConsulta + '\'' +
                ", dateConsulta=" + dateConsulta +
                ", tipoConsulta='" + tipoConsulta + '\'' +
                ", valorMedioConsulta=" + valorMedioConsulta +
                ", dentista=" + dentista +
                ", cliente=" + cliente +
                '}';
    }

    public static ConsultaBuilder builder() {
        return new ConsultaBuilder();
    }

    public static class ConsultaBuilder {
        private String idConsulta;
        private LocalDate dateConsulta;
        private String tipoConsulta;
        private Double valorMedioConsulta;
        private Dentista dentista;
        private Cliente cliente;

        public ConsultaBuilder idConsulta(String idConsulta) {
            this.idConsulta = idConsulta;
            return this;
        }

        public ConsultaBuilder dateConsulta(LocalDate dateConsulta) {
            this.dateConsulta = dateConsulta;
            return this;
        }

        public ConsultaBuilder tipoConsulta(String tipoConsulta) {
            this.tipoConsulta = tipoConsulta;
            return this;
        }

        public ConsultaBuilder valorMedioConsulta(Double valorMedioConsulta) {
            this.valorMedioConsulta = valorMedioConsulta;
            return this;
        }

        public ConsultaBuilder dentista(Dentista dentista) {
            this.dentista = dentista;
            return this;
        }

        public ConsultaBuilder cliente(Cliente cliente) {
            this.cliente = cliente;
            return this;
        }

        public Consulta build() {
            return new Consulta(idConsulta, dateConsulta, tipoConsulta, valorMedioConsulta, dentista, cliente);
        }
    }

}
