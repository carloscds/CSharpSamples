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
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => new {c.PedidoId, c.ProdutoId});
            builder.Property(p => p.Quantidade)
                .HasPrecision(10,2);
            builder.Property(p => p.Valor)
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Produto)
                .WithOne()
                .HasForeignKey<PedidoItem>(p => p.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.PedidoItem)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(p => p.ProdutoId).IsUnique(false);

        }
    }
}
