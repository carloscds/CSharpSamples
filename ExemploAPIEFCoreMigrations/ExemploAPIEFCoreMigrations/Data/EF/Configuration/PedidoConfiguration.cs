using ExemploAPIEFCoreMigrations.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploAPIEFCoreMigrations.Data.EF.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Valor)
                .HasPrecision(18, 2);
            builder.HasOne(p => p.Cliente)
                    .WithMany(p => p.Pedidos);
            builder.HasIndex(p => p.ClienteId).IsUnique(false);
        }
    }
}
