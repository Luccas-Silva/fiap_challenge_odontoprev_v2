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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaApplicationService _consultaApplicationService;

        public ConsultaController(IConsultaApplicationService consultaApplicationService)
        {
            _consultaApplicationService = consultaApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todas as consultas", Description = "Retorna uma lista de todas as consultas.")]
        [SwaggerResponse(200, "Consultas encontradas com sucesso.", typeof(IEnumerable<ConsultaDto>))]
        public async Task<IActionResult> Get()
        {
            var consultas = await _consultaApplicationService.GetAllAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma consulta por ID", Description = "Retorna uma consulta específica com base no ID.")]
        [SwaggerResponse(200, "Consulta encontrada com sucesso.", typeof(ConsultaDto))]
        [SwaggerResponse(404, "Consulta não encontrada.")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var consulta = await _consultaApplicationService.GetByIdAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova consulta", Description = "Cria uma nova consulta com os dados fornecidos.")]
        [SwaggerResponse(201, "Consulta criada com sucesso.", typeof(ConsultaDto))]
        [SwaggerResponse(400, "Requisição inválida.")]
        public async Task<IActionResult> Create([FromBody] ConsultaDto consultaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _consultaApplicationService.AddAsync(consultaDto);
                return CreatedAtAction(nameof(GetById), new { id = consultaDto.IdConsulta }, consultaDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar consulta: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma consulta", Description = "Atualiza uma consulta existente com base no ID.")]
        [SwaggerResponse(204, "Consulta atualizada com sucesso.")]
        [SwaggerResponse(400, "Requisição inválida.")]
        [SwaggerResponse(404, "Consulta não encontrada.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ConsultaDto consultaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultaExistente = await _consultaApplicationService.GetByIdAsync(id);
            if (consultaExistente == null)
            {
                return NotFound();
            }

            consultaDto.IdConsulta = consultaExistente.IdConsulta;

            try
            {
                await _consultaApplicationService.UpdateAsync(consultaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar consulta: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta uma consulta", Description = "Deleta uma consulta com base no ID.")]
        [SwaggerResponse(204, "Consulta deletada com sucesso.")]
        [SwaggerResponse(404, "Consulta não encontrada.")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var consultaExistente = await _consultaApplicationService.GetByIdAsync(id);
            if (consultaExistente == null)
            {
                return NotFound();
            }

            try
            {
                await _consultaApplicationService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar consulta: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

    }
}
