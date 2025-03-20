using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace C__Challenge_v2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public ClienteController(IClienteApplicationService clienteApplicationService, IUsuarioApplicationService usuarioApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os clientes", Description = "Retorna uma lista de clientes com dados do usuário.")]
        [SwaggerResponse(200, "Clientes encontrados com sucesso.", typeof(IEnumerable<ClienteDto>))]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteApplicationService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Obtém um cliente pelo CPF/CNPJ", Description = "Retorna um cliente específico com dados do usuário.")]
        [SwaggerResponse(200, "Cliente encontrado com sucesso.", typeof(ClienteDto))]
        [SwaggerResponse(404, "Cliente não encontrado.")]
        public async Task<IActionResult> GetByCpfCnpj(string cpfCnpj)
        {
            var cliente = await _clienteApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo cliente", Description = "Cria um novo cliente com os dados do usuário.")]
        [SwaggerResponse(201, "Cliente criado com sucesso.", typeof(ClienteDto))]
        [SwaggerResponse(400, "Requisição inválida.")]
        public async Task<IActionResult> Create([FromBody] ClienteCreateDto clienteCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioApplicationService.AddAsync(clienteCreateDTO.Usuario);

            clienteCreateDTO.Cliente.UsuarioId = clienteCreateDTO.Usuario.IdUsuario;

            await _clienteApplicationService.AddAsync(clienteCreateDTO.Cliente);

            var clienteCriado = await _clienteApplicationService.GetByCpfCnpjAsync(clienteCreateDTO.Usuario.CpfCnpj);

            if (clienteCriado == null)
            {
                return StatusCode(500, "Erro ao buscar cliente criado.");
            }

            return CreatedAtAction(nameof(GetByCpfCnpj), new { cpfCnpj = clienteCreateDTO.Usuario.CpfCnpj }, clienteCriado);
        }

        [HttpPut("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Atualiza um cliente", Description = "Atualiza um cliente existente pelo CPF/CNPJ.")]
        [SwaggerResponse(204, "Cliente atualizado com sucesso.")]
        [SwaggerResponse(400, "Requisição inválida.")]
        [SwaggerResponse(404, "Cliente não encontrado.")]
        public async Task<IActionResult> Update(string cpfCnpj, [FromBody] ClienteDto cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExistente = await _clienteApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            cliente.IdCliente = clienteExistente.IdCliente;

            await _clienteApplicationService.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{cpfCnpj}")]
        [SwaggerOperation(Summary = "Deleta um cliente", Description = "Deleta um cliente pelo CPF/CNPJ.")]
        [SwaggerResponse(204, "Cliente deletado com sucesso.")]
        [SwaggerResponse(404, "Cliente não encontrado.")]
        public async Task<IActionResult> Delete(string cpfCnpj)
        {
            var clienteExistente = await _clienteApplicationService.GetByCpfCnpjAsync(cpfCnpj);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            await _clienteApplicationService.DeleteAsync(cpfCnpj);
            return NoContent();
        }
    }
}
