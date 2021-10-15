using ExemploAPIEFCoreMigrations.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExemploAPIEFCoreMigrations.Data.EF
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Pedido> Pedido {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
