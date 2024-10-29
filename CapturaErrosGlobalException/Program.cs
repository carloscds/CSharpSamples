using CapturaErros.ExceptionHandler;
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
            //builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandlerProblemDetail>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();
            app.UseAuthorization();
            app.MapControllers();
            app.UseExceptionHandler();
            app.Run();
        }
    }
}
