using APIComIoC.API;
using APIComIoC.InfraEstrutura.Data;
using APIComIoC.Services;
using Microsoft.EntityFrameworkCore;

namespace APIComIoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCustomServices();
            builder.Services.AddDatabase();
            builder.Services.AddServices();

            var app = builder.Build();
            app.UseOpenAPI();
            app.UseSecurity();
            app.UseDefaultServices();
            app.Run();
        }
    }
}
