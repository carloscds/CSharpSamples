using Microsoft.AspNetCore.Mvc;

namespace HttpResilience.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly HttpClient _client;
        public TesteController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("TesteAPI");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _client.GetAsync("");
            var resultMsg = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return Ok($"Chamada: {resultMsg}");
            }
            return BadRequest($"API Result: {resultMsg}");
        }
    }
}
