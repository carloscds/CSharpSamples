using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using System.Net.Http;

namespace InjecaoDependenciaHttpFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExemploHttpController : ControllerBase
    {

        private readonly HttpClient _client;
        public ExemploHttpController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string local)
        {
            if(string.IsNullOrEmpty(local))
            {
               local = "America/Sao_Paulo";
            }
            var url = $"http://worldtimeapi.org/api/timezone/{local}";
            var response = await _client.GetAsync(url);
            return Ok(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("locais")]
        public async Task<IActionResult> GetLocais()
        {
            var url = $"http://worldtimeapi.org/api/timezone";
            var response = await _client.GetAsync(url);
            return Ok(await response.Content.ReadAsStringAsync());
        }


    }
}
