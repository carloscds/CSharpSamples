using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSample.Domain;

namespace EFCoreSample.EF.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.Preco)
                .HasPrecision(18,2);
            builder.HasOne(p => p.Grupo)
               .WithMany(p => p.Produto)
               .HasForeignKey(p => p.GrupoId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(e => e.GrupoId).IsUnique(false);
            builder.HasIndex(e => e.Nome).IsUnique(false);

        }
    }
}