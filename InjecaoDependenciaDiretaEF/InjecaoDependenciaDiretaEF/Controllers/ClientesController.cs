using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InjecaoDependenciaDiretaEF.Data;
using InjecaoDependenciaDiretaEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using InjecaoDependenciaDiretaEF.Services;

namespace InjecaoDependenciaDiretaEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly AplicacaoContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientesController(
            ILogger<ClientesController> logger,
            AplicacaoContext db,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _db.Cliente;
        }

        [HttpGet]
        [Route("Email")]
        public string Email()
        {
            var email = _httpContextAccessor.HttpContext.RequestServices.GetService<IEnvioEmail>();
            return email.Enviar();
        }

    }
}
