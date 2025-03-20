using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Application.DTOs
{
    public class DentistaDto
    {
        public Guid IdDentista { get; set; }

        [Required(ErrorMessage = "O campo CEP da Clínica é obrigatório")]
        [DisplayName("CEP da Clínica")]
        [StringLength(10)]
        public string CepClinica { get; set; }

        [Required(ErrorMessage = "O campo Nome da Clínica é obrigatório")]
        [DisplayName("Nome da Clínica")]
        [StringLength(100)]
        public string NomeClinica { get; set; }

        [Required(ErrorMessage = "O campo Tipo da Clínica é obrigatório")]
        [DisplayName("Tipo da Clínica")]
        [StringLength(100)]
        public string TipoClinica { get; set; }

        [Required(ErrorMessage = "O campo Alvará de Funcionamento é obrigatório")]
        [DisplayName("Alvará de Funcionamento")]
        public char AlvaraFuncionamento { get; set; }

        [DisplayName("Site / Redes Sociais")]
        [StringLength(255)]
        public string SiteRedesSocial { get; set; }

        public Guid UsuarioId { get; set; }
        public object CpfCnpj { get; internal set; }
    }
}
