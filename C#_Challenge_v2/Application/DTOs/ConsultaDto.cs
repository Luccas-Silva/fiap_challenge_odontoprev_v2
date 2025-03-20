using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Application.DTOs
{
    public class ConsultaDto
    {
        public Guid IdConsulta { get; set; }

        [Required(ErrorMessage = "O campo Data da Consulta é obrigatório")]
        [DisplayName("Data da Consulta")]
        public DateOnly DateConsulta { get; set; }

        [Required(ErrorMessage = "O campo Tipo da Consulta é obrigatório")]
        [DisplayName("Tipo da Consulta")]
        [StringLength(100)]
        public string TipoConsulta { get; set; }

        [Required(ErrorMessage = "O campo Valor Médio da Consulta é obrigatório")]
        [DisplayName("Valor Médio da Consulta")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor médio da consulta deve ser um número positivo")]
        public double ValorMedioConsulta { get; set; }

        [Required(ErrorMessage = "O campo Dentista é obrigatório")]
        public string DentistaCpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public string ClienteCpfCnpj { get; set; }
    }
}
