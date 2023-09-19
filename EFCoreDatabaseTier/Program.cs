using EFCoreDatabaseTier.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseTierSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Banco")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapGet("/", (HttpContext httpContext, Contexto db) =>
            {
                return Results.Ok(db.Cliente);
            });

            app.Run();
        }
    }
}