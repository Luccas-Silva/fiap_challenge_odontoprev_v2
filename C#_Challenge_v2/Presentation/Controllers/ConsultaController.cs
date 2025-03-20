using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Challenge_v2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController(IConsultaApplicationService consultaApplicationService) : ControllerBase
    {
        public readonly IConsultaApplicationService _consultaApplicationService = consultaApplicationService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consultas = await _consultaApplicationService.GetAllAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Create([FromBody] ConsultaDto consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _consultaApplicationService.AddAsync(consulta);
            return CreatedAtAction(nameof(GetById), new { id = consulta.IdConsulta }, consulta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ConsultaDto consulta)
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

            consulta.IdConsulta = id;

            await _consultaApplicationService.UpdateAsync(consulta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var consultaExistente = await _consultaApplicationService.GetByIdAsync(id);
            if (consultaExistente == null)
            {
                return NotFound();
            }

            await _consultaApplicationService.DeleteAsync(id);
            return NoContent();
        }

    }
}
