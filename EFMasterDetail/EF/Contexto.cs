using EFMasterDetail.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.EF
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set;}
        public DbSet<Produto> Produto { get; set;}
        public DbSet<Pedido> Pedido { get; set;}
        public DbSet<PedidoItem> PedidoItem { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
