using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Domain.Entities
{
    [Table("tbV2_Dentista")]
    public class DentistaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual UsuarioEntity Usuario { get; set; }

        public virtual ICollection<ConsultaEntity> Consultas { get; set; } = new List<ConsultaEntity>();
    }
}
