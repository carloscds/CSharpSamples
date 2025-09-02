using EFMasterDetail.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMasterDetail.EF.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(100);

            builder.HasMany(p => p.Pedido)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
