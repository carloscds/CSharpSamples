using Microsoft.AspNetCore.Mvc;

namespace APIChamada.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }
    }
}
