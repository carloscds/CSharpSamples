using Microsoft.AspNetCore.Mvc;

namespace CircuitoCurto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ShortCircuit]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() => Ok("ShortCircuit");
    }

    [ApiController]
    [Route("[controller]")]
    public class Home3Controller : ControllerBase
    {
        [ShortCircuit]
        public IActionResult Get() => Ok("ShortCircuit no Methodo");
    }

    [ApiController]
    [Route("[controller]")]
    public class Home2Controller : ControllerBase
    {
        public IActionResult Get() => Ok("Sem ShortCircuit");
    }

    [ApiController]
    [Route("robots.txt")]
    [ShortCircuit]
    public class RobotsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("User-agent: *\nDisallow:", "text/plain");
    }
}
