using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Challenge_v2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Dados retornados com sucesso!");
        }

    }
}
