using CapturaErros.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapturaErros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var simulacao = new SimulacaoErro();
            simulacao.SimulaErro();
            return BadRequest();
        }

        [HttpPost("ShowError")]
        public IActionResult ShowError()
        {
            return Ok();
        }
    }
}
