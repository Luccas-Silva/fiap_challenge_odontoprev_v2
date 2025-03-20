using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C__Challenge_v2.Application.DTOs
{
    public class ClienteDto
    {
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [DisplayName("CEP")]
        [StringLength(10)]
        public string Cep { get; set; }

        [DisplayName("Tipo de Plano")]
        [Required(ErrorMessage = "O campo Tipo de Plano é obrigatório")]
        [StringLength(50)]
        public string TipoPlano { get; set; }

        public Guid CpfCnpj { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
