using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Domain.Entities
{
    [Table("tbV2_Cliente")]
    public class ClienteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [DisplayName("CEP")]
        [StringLength(10)] 
        public string Cep { get; set; }

        [DisplayName("Tipo de Plano")]
        [Required(ErrorMessage = "O campo Tipo de Plano é obrigatório")]
        [StringLength(50)] 
        public string TipoPlano { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual UsuarioEntity Usuario { get; set; }

        public virtual ICollection<ConsultaEntity> Consultas { get; set; } = new List<ConsultaEntity>();
    }
}
