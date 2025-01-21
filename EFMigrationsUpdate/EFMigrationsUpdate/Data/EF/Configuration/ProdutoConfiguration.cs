using EFMigrationsUpdate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFMigrationsUpdate.Data.EF.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Nome)
                   .HasMaxLength(200);
            builder.Property(x => x.Preco)
                   .HasPrecision(18, 2);
            builder.Property(x => x.Custo)
                   .HasPrecision(18, 2);
            builder.HasIndex(e => e.Key).IsUnique();
        }
    }
}
