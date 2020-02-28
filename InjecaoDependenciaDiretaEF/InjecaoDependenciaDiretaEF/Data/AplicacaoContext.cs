using InjecaoDependenciaDiretaEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaDiretaEF.Data
{
    public class AplicacaoContext : DbContext
    {
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options) : base(options) 
        {
            SeedData();
        }
    
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                .Property(p => p.Id)
                .IsRequired();
            builder.Entity<Cliente>()
                .Property(p => p.Nome)
                .HasMaxLength(100);

            base.OnModelCreating(builder);
        }

        private void SeedData()
        {
            Cliente.Add(new Models.Cliente { Nome = "Carlos", LimiteCredito = 1000 });
            Cliente.Add(new Models.Cliente { Nome = "Maria", LimiteCredito = 5000 });
            Cliente.Add(new Models.Cliente { Nome = "Jose", LimiteCredito = 500 });
            Cliente.Add(new Models.Cliente { Nome = "Joana", LimiteCredito = 600 });
            SaveChanges();
        }

    }
}
