using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InjecaoDependenciaASPNETCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IServico _servico;
        private readonly ExecutaServico _executaServico;
        public HomeController(IServico servico, ExecutaServico executaServico)
        {
            _servico = servico;
            _executaServico = executaServico;
        }

        [HttpGet]
        public string Get()
        {
            var textoServico = _servico.RetornaValor();
            var textoExecutaServico = _executaServico.RetornaServicoExecutado();
            return $"Servico: {textoServico} - ExecutaServico: {textoExecutaServico}";
        }
    }
}
