using CapturaErros.Middleware;
using Serilog;

namespace CapturaErros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSerilog(s => s.WriteTo.Console());

            var app = builder.Build();

            app.UseAuthorization();
            app.UseMiddleware<MiddlewareException>();
            app.MapControllers();
            app.Run();
        }
    }
}
