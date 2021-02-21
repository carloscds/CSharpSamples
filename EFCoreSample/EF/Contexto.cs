using System.Reflection;
using EFCoreSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.EF
{
    public class Contexto : DbContext
    {
        public DbSet<Grupo> Grupo {get; set;}
        public DbSet<Produto> Produto {get; set;}

        public Contexto(DbContextOptions<Contexto> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}