using ExemploAPIEFCoreMigrations.Data.EF;
using ExemploAPIEFCoreMigrations.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploAPIEFCoreMigrations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly Contexto _contexto;

        public ClientesController(ILogger<ClientesController> logger, Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;  
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>),200)]
        public IActionResult GetAll()
        {
            var dados = _contexto.Cliente
                            .Include(i => i.Area);
            return Ok(dados);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), 200)]
        public IActionResult GetId(int id)
        {
            var dados = _contexto.Cliente
                        .Include(i => i.Area)
                        .FirstOrDefault(w => w.Id == id);
            return Ok(dados);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            _contexto.Cliente.Add(cliente);
            _contexto.SaveChanges();
            return Created("", cliente.Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            _contexto.Attach(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cli = _contexto.Cliente.FirstOrDefault(w => w.Id == id);
            if(cli == null)
            {
                return BadRequest("Cliente não encontrado!");
            }
            _contexto.Remove(cli);
            return Ok();
        }

    }
}
