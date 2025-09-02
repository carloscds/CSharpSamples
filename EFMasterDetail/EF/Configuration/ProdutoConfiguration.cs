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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.Property(p => p.Valor)
                .HasPrecision(18, 2);
        }
    }
}
