using APIComIoC.Domain.DTO;
using APIComIoC.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIComIoC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public ClienteController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ClienteDTO cliente)
        {
            _usuarioService.Add(cliente);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteDTO cliente)
        {
            _usuarioService.Update(cliente);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(int clienteID)
        {
            _usuarioService.Delete(clienteID);
            return Ok();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var clientes = _usuarioService.GetAll();
            return Ok(clientes);
        }

    }
}
