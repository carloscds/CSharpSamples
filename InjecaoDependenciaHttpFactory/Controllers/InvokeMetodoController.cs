using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using System.Net.Http;
using InjecaoDependenciaHttpFactory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDependenciaHttpFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvokeMetodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAction()
        {
            var tempo = HttpContext.RequestServices.GetService<ICurrentTime>();
            return Ok(tempo.GetCurrentTime());
        }
    }
}