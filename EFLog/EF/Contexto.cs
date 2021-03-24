using EFLog.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFLog.EF
{
    public class Contexto : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(local); initial catalog=EFCoreSample; user id=teste; password=teste;")
                           .EnableSensitiveDataLogging()
                          .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

    }


}
