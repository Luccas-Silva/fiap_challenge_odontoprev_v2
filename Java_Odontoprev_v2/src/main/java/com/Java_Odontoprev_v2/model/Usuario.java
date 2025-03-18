package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;
import java.util.Objects;


@Entity
public class Usuario {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String idUsuario;

    private String cpf_cnpj;
    private String nome;
    private LocalDate dataNascimento;
    private String Email;
    private String Celular;

    public Usuario() {
    }
    public Usuario(String idUsuario, String cpf_cnpj, String nome, LocalDate dataNascimento, String email, String celular) {
        this.idUsuario = idUsuario;
        this.cpf_cnpj = cpf_cnpj;
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        Email = email;
        Celular = celular;
    }

    public String getIdUsuario() {
        return idUsuario;
    }
    public void setIdUsuario(String idUsuario) {
        this.idUsuario = idUsuario;
    }

    public String getCpf_cnpj() {
        return cpf_cnpj;
    }
    public void setCpf_cnpj(String cpf_cnpj) {
        this.cpf_cnpj = cpf_cnpj;
    }

    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }

    public LocalDate getDataNascimento() {
        return dataNascimento;
    }
    public void setDataNascimento(LocalDate dataNascimento) {
        this.dataNascimento = dataNascimento;
    }

    public String getEmail() {
        return Email;
    }
    public void setEmail(String email) {
        Email = email;
    }

    public String getCelular() {
        return Celular;
    }
    public void setCelular(String celular) {
        Celular = celular;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Usuario usuario = (Usuario) o;
        return Objects.equals(idUsuario, usuario.idUsuario);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idUsuario);
    }

    @Override
    public String toString() {
        return "Usuario{" +
                "idUsuario='" + idUsuario + '\'' +
                ", cpf_cnpj='" + cpf_cnpj + '\'' +
                ", nome='" + nome + '\'' +
                ", dataNascimento=" + dataNascimento +
                ", Email='" + Email + '\'' +
                ", Celular='" + Celular + '\'' +
                '}';
    }

    public static UsuarioBuilder builder() {
        return new UsuarioBuilder();
    }

    public static class UsuarioBuilder {
        private String idUsuario;
        private String cpf_cnpj;
        private String nome;
        private LocalDate dataNascimento;
        private String Email;
        private String Celular;

        public UsuarioBuilder idUsuario(String idUsuario) {
            this.idUsuario = idUsuario;
            return this;
        }

        public UsuarioBuilder cpf_cnpj(String cpf_cnpj) {
            this.cpf_cnpj = cpf_cnpj;
            return this;
        }

        public UsuarioBuilder nome(String nome) {
            this.nome = nome;
            return this;
        }

        public UsuarioBuilder dataNascimento(LocalDate dataNascimento) {
            this.dataNascimento = dataNascimento;
            return this;
        }

        public UsuarioBuilder Email(String Email) {
            this.Email = Email;
            return this;
        }

        public UsuarioBuilder Celular(String Celular) {
            this.Celular = Celular;
            return this;
        }

        public Usuario build() {
            return new Usuario(idUsuario, cpf_cnpj, nome, dataNascimento, Email, Celular);
        }
    }

}
