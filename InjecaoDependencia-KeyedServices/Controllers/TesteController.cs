using InjecaoDependencia_KeyedServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace InjecaoDependencia_KeyedServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly IMessage _msgA;
        private readonly IMessage _msgB;
        public TesteController([FromKeyedServices("A")] IMessage mensagemA,
                               [FromKeyedServices("B")] IMessage mensagemB)
        {
            _msgA = mensagemA;
            _msgB = mensagemB;
        }

        [HttpGet("A")]
        public IActionResult GetA()
        {
            return Ok(_msgA.Send());
        }

        [HttpGet("B")]
        public IActionResult GetB()
        {
            return Ok(_msgB.Send());
        }

    }

}
