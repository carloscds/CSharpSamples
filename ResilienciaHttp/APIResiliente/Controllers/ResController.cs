using Microsoft.AspNetCore.Mvc;

namespace APIResiliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResController : ControllerBase
    {
        private readonly ILogger<ResController> _logger;
        private readonly HttpClient _client;

        public ResController(ILogger<ResController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _client = clientFactory.CreateClient("resiliente");
            _client.BaseAddress = new Uri("https://localhost:5001/");    
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _client.GetAsync("teste");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok("Retorno API Chamada: "+content);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar dados "+ex.Message);
                return StatusCode(500, "Erro ao buscar dados: "+ex.Message);
            }
        }
    }
}
