using APIComIoC.InfraEstrutura.Data;
using APIComIoC.Services;
using Microsoft.EntityFrameworkCore;

namespace APIComIoC.API
{
    public static class IoC
    {
        public static void AddCustomServices(this IServiceCollection app)
        {
            app.AddControllers();
            app.AddOpenApi();
        }

        public static void AddDatabase(this IServiceCollection app)
        {
            app.AddDbContext<APIContext>(o =>
                o.UseInMemoryDatabase("BancoEmMemoria"));
        }

        public static void AddServices(this IServiceCollection app)
        {
            app.AddScoped<IUsuarioService, UsuarioService>();
        }

        public static void UseOpenAPI(this WebApplication app)
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
            });
        }

        public static void UseDefaultServices(this WebApplication app)
        {
            app.MapControllers();
            app.MapGet("/", () => "API Com IoC funcionando!");
        }

        public static void UseSecurity(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
