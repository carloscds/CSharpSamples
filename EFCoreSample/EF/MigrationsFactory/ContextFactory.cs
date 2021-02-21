using System.IO;
using EFCoreSample.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCoreSample.MigrationsFactory
{
    public class ContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();
                var builder = new DbContextOptionsBuilder<Contexto>()
                        .UseSqlServer(configuration.GetConnectionString("BancoSQL"))
                        .UseLoggerFactory(LoggerFactory.Create((builder => builder.AddConsole())));
                return new Contexto(builder.Options);
        }
    }
}