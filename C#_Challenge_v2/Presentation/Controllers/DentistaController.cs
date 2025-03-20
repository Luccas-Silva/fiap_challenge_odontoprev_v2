using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace C__Challenge_v2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly IDentistaApplicationService _dentistaApplicationService;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public DentistaController(IDentistaApplicationService dentistaApplicationService, IUsuarioApplicationService usuarioApplicationService)
        {
            _dentistaApplicationService = dentistaApplicationService;
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os dentistas", Description = "Retorna uma lista de dentistas.")]
        [SwaggerResponse(200, "Dentistas encontrados com sucesso.", typeof(IEnumerable<DentistaDto>))]
        public async Task<IActionResult> Get()
        {
            var dentistas = await _dentistaApplicationService.GetAllAsync();
            return Ok(dentistas);
        }

        [HttpGet("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Obtém um dentista pelo CPF/CNPJ", Description = "Retorna um dentista específico.")]
        [SwaggerResponse(200, "Dentista encontrado com sucesso.", typeof(DentistaDto))]
        [SwaggerResponse(404, "Dentista não encontrado.")]
        public async Task<IActionResult> GetByCpfCnpj(string cpfCnpj)
        {
            var dentista = await _dentistaApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (dentista == null)
            {
                return NotFound();
            }
            return Ok(dentista);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo dentista", Description = "Cria um novo dentista com os dados do usuário.")]
        [SwaggerResponse(201, "Dentista criado com sucesso.", typeof(DentistaDto))]
        [SwaggerResponse(400, "Requisição inválida.")]
        public async Task<IActionResult> Create([FromBody] DentistaCreateDto dentistaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioApplicationService.AddAsync(dentistaCreateDto.Usuario);
            dentistaCreateDto.Dentista.UsuarioId = dentistaCreateDto.Usuario.IdUsuario;
            await _dentistaApplicationService.AddAsync(dentistaCreateDto.Dentista);

            return CreatedAtAction(nameof(GetByCpfCnpj), new { cpfCnpj = dentistaCreateDto.Dentista.CpfCnpj }, dentistaCreateDto.Dentista);
        }

        [HttpPut("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Atualiza um dentista", Description = "Atualiza um dentista existente pelo CPF/CNPJ.")]
        [SwaggerResponse(204, "Dentista atualizado com sucesso.")]
        [SwaggerResponse(400, "Requisição inválida.")]
        [SwaggerResponse(404, "Dentista não encontrado.")]
        public async Task<IActionResult> Update(string cpfCnpj, [FromBody] DentistaDto dentista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dentistaExistente = await _dentistaApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (dentistaExistente == null)
            {
                return NotFound();
            }

            dentista.IdDentista = dentistaExistente.IdDentista;

            await _dentistaApplicationService.UpdateAsync(dentista);
            return NoContent();
        }

        [HttpDelete("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Deleta um dentista", Description = "Deleta um dentista com base no CPF/CNPJ.")]
        [SwaggerResponse(204, "Dentista deletado com sucesso.")]
        [SwaggerResponse(404, "Dentista não encontrado.")]
        public async Task<IActionResult> Delete(string cpfCnpj)
        {
            var dentistaExistente = await _dentistaApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (dentistaExistente == null)
            {
                return NotFound();
            }

            await _dentistaApplicationService.DeleteAsync(cpfCnpj);
            return NoContent();
        }

    }
}
