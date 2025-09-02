using EFMasterDetail.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.EF.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Total)
                .HasPrecision(18,2);

            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Pedido)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PedidoItem)
                .WithOne()
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.ClienteId).IsUnique(false);

        }
    }
}
