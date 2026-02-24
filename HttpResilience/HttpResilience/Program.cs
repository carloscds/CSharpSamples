using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace HttpResilience
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddHttpClient("TesteAPI", s => s.BaseAddress = new Uri("https://localhost:6001/"))
                .AddResilienceHandler("TesteAPI-pipeline", builder => 
                {
                    builder.AddRetry(new HttpRetryStrategyOptions
                    {
                        MaxRetryAttempts = 3, // 3 tentativas
                        Delay = TimeSpan.FromSeconds(3), // aguarda 3 segundos inicialmente
                        BackoffType = DelayBackoffType.Exponential // vai dobrando: 3, 6, 12 e depois falha
                    });
                    builder.AddTimeout(TimeSpan.FromSeconds(3)); // tempo de timeout da chamada
                });

            var app = builder.Build();
            app.MapOpenApi("/openapi/v1.json");
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
            });
            app.MapControllers();
            app.MapGet("/" , () => "HTTP Resilience - 2026 Carlos dos Santos ");
            app.UseMiddleware<ResilienceMiddlewareException>();
            app.Run();
        }
    }
}
