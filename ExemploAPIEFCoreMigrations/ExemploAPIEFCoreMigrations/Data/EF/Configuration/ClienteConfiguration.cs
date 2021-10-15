using ExemploAPIEFCoreMigrations.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploAPIEFCoreMigrations.Data.EF.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RazaoSocial)
                .HasMaxLength(100);
            builder.Property(e => e.Fantasia)
                .HasMaxLength(100);
            builder.Property(e => e.CNPJCPF)
                .HasMaxLength(18);
            builder.Property(e => e.Cidade)
                .HasMaxLength(100);

            builder.HasOne(e => e.Area)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(e => e.AreaId).IsUnique(false);

            builder.HasMany(e => e.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
