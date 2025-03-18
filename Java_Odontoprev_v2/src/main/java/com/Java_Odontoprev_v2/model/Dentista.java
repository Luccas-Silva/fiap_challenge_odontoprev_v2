package com.Java_Odontoprev_v2.model;

import jakarta.persistence.*;
import lombok.*;

import java.util.List;
import java.util.Objects;

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
    @GeneratedValue(strategy = GenerationType.UUID)
    private String idDentista;

    private String cepClinica;
    private String nomeClinica;
    private String tipoClinica;
    private boolean alvaraFuncionamento;
    private String siteRedesSocial;

    @OneToOne(cascade = CascadeType.ALL)
    private Usuario usuario;

    @OneToMany(mappedBy = "dentista", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<Consulta> consultas;

    public Dentista() {
    }
    public Dentista(String idDentista, String cepClinica, String nomeClinica, String tipoClinica, boolean alvaraFuncionamento, String siteRedesSocial, Usuario usuario, List<Consulta> consultas) {
        this.idDentista = idDentista;
        this.cepClinica = cepClinica;
        this.nomeClinica = nomeClinica;
        this.tipoClinica = tipoClinica;
        this.alvaraFuncionamento = alvaraFuncionamento;
        this.siteRedesSocial = siteRedesSocial;
        this.usuario = usuario;
        this.consultas = consultas;
    }

    public String getIdDentista() {
        return idDentista;
    }
    public void setIdDentista(String idDentista) {
        this.idDentista = idDentista;
    }

    public String getCepClinica() {
        return cepClinica;
    }
    public void setCepClinica(String cepClinica) {
        this.cepClinica = cepClinica;
    }

    public String getNomeClinica() {
        return nomeClinica;
    }
    public void setNomeClinica(String nomeClinica) {
        this.nomeClinica = nomeClinica;
    }

    public String getTipoClinica() {
        return tipoClinica;
    }
    public void setTipoClinica(String tipoClinica) {
        this.tipoClinica = tipoClinica;
    }

    public boolean isAlvaraFuncionamento() {
        return alvaraFuncionamento;
    }
    public void setAlvaraFuncionamento(boolean alvaraFuncionamento) {
        this.alvaraFuncionamento = alvaraFuncionamento;
    }

    public String getSiteRedesSocial() {
        return siteRedesSocial;
    }
    public void setSiteRedesSocial(String siteRedesSocial) {
        this.siteRedesSocial = siteRedesSocial;
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
        Dentista dentista = (Dentista) o;
        return Objects.equals(idDentista, dentista.idDentista);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idDentista);
    }

    @Override
    public String toString() {
        return "Dentista{" +
                "idDentista='" + idDentista + '\'' +
                ", cepClinica='" + cepClinica + '\'' +
                ", nomeClinica='" + nomeClinica + '\'' +
                ", tipoClinica='" + tipoClinica + '\'' +
                ", alvaraFuncionamento=" + alvaraFuncionamento +
                ", siteRedesSocial='" + siteRedesSocial + '\'' +
                ", usuario=" + usuario +
                ", consultas=" + consultas +
                '}';
    }

    public static DentistaBuilder builder() {
        return new DentistaBuilder();
    }

    public static class DentistaBuilder {
        private String idDentista;
        private String cepClinica;
        private String nomeClinica;
        private String tipoClinica;
        private boolean alvaraFuncionamento;
        private String siteRedesSocial;
        private Usuario usuario;
        private List<Consulta> consultas;

        public DentistaBuilder idDentista(String idDentista) {
            this.idDentista = idDentista;
            return this;
        }

        public DentistaBuilder cepClinica(String cepClinica) {
            this.cepClinica = cepClinica;
            return this;
        }

        public DentistaBuilder nomeClinica(String nomeClinica) {
            this.nomeClinica = nomeClinica;
            return this;
        }

        public DentistaBuilder tipoClinica(String tipoClinica) {
            this.tipoClinica = tipoClinica;
            return this;
        }

        public DentistaBuilder alvaraFuncionamento(boolean alvaraFuncionamento) {
            this.alvaraFuncionamento = alvaraFuncionamento;
            return this;
        }

        public DentistaBuilder siteRedesSocial(String siteRedesSocial) {
            this.siteRedesSocial = siteRedesSocial;
            return this;
        }

        public DentistaBuilder usuario(Usuario usuario) {
            this.usuario = usuario;
            return this;
        }

        public DentistaBuilder consultas(List<Consulta> consultas) {
            this.consultas = consultas;
            return this;
        }

        public Dentista build() {
            return new Dentista(idDentista, cepClinica, nomeClinica, tipoClinica, alvaraFuncionamento, siteRedesSocial, usuario, consultas);
        }
    }

}
