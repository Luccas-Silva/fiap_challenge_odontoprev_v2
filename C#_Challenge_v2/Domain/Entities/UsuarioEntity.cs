using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Domain.Entities
{
    [Table("tbV2_Usuario")]
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        [DisplayName("CPF/CNPJ")]
        [StringLength(20)] 
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [DisplayName("Nome")]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [StringLength(255)] 
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório")]
        [DisplayName("Celular")]
        [StringLength(20)] 
        public string Celular { get; set; }
    }
}
