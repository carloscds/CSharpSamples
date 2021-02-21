using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSample.Domain;

namespace EFCoreSample.EF.Configuration
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasMany(p => p.Produto)
                .WithOne(p => p.Grupo)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(e => e.Nome).IsUnique(false);

        }
    }
}