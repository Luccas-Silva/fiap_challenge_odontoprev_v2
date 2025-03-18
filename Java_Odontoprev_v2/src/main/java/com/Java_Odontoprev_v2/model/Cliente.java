package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Cliente {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String idCliente;

    private String cep;
    private String tipoPlano;

    @OneToOne(cascade = CascadeType.ALL)
    private Usuario usuario;

    @OneToMany(mappedBy = "cliente", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<Consulta> consultas;

    public Cliente() {
    }
    public Cliente(String idCliente, String cep, String tipoPlano, Usuario usuario, List<Consulta> consultas) {
        this.idCliente = idCliente;
        this.cep = cep;
        this.tipoPlano = tipoPlano;
        this.usuario = usuario;
        this.consultas = consultas;
    }

    public String getIdCliente() {
        return idCliente;
    }
    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public String getCep() {
        return cep;
    }
    public void setCep(String cep) {
        this.cep = cep;
    }

    public String getTipoPlano() {
        return tipoPlano;
    }
    public void setTipoPlano(String tipoPlano) {
        this.tipoPlano = tipoPlano;
    }

    public Usuario getUsuario() {
        return usuario;
    }
    public void setUsuario(Usuario usuario) {
        this.usuario = usuario;
    }

    public List<Consulta> getConsultas() {
        return consultas;
    }
    public void setConsultas(List<Consulta> consultas) {
        this.consultas = consultas;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Cliente cliente = (Cliente) o;
        return Objects.equals(idCliente, cliente.idCliente);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idCliente);
    }

    @Override
    public String toString() {
        return "Cliente{" +
                "idCliente='" + idCliente + '\'' +
                ", cep='" + cep + '\'' +
                ", tipoPlano='" + tipoPlano + '\'' +
                ", usuario=" + usuario +
                ", consultas=" + consultas +
                '}';
    }

    public static ClienteBuilder builder() {
        return new ClienteBuilder();
    }

    public static class ClienteBuilder {
        private String idCliente;
        private String cep;
        private String tipoPlano;
        private Usuario usuario;
        private List<Consulta> consultas;

        public ClienteBuilder idCliente(String idCliente) {
            this.idCliente = idCliente;
            return this;
        }

        public ClienteBuilder cep(String cep) {
            this.cep = cep;
            return this;
        }

        public ClienteBuilder tipoPlano(String tipoPlano) {
            this.tipoPlano = tipoPlano;
            return this;
        }

        public ClienteBuilder usuario(Usuario usuario) {
            this.usuario = usuario;
            return this;
        }

        public ClienteBuilder consultas(List<Consulta> consultas) {
            this.consultas = consultas;
            return this;
        }

        public Cliente build() {
            return new Cliente(idCliente, cep, tipoPlano, usuario, consultas);
        }
    }

}
