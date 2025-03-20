using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Challenge_v2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController(IDentistaApplicationService dentistaApplicationService) : ControllerBase
    {
        public readonly IDentistaApplicationService _dentistaApplicationService = dentistaApplicationService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dentistas = await _dentistaApplicationService.GetAllAsync();
            return Ok(dentistas);
        }

        [HttpGet("{cpfCnpj}")]
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
        public async Task<IActionResult> Create([FromBody] DentistaDto dentista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dentistaApplicationService.AddAsync(dentista);
            return CreatedAtAction(nameof(GetByCpfCnpj), new { cpfCnpj = dentista.UsuarioId }, dentista);
        }

        [HttpPut("{cpfCnpj}")]
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
