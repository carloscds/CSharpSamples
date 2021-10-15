using ExemploAPIEFCoreMigrations.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploAPIEFCoreMigrations.Data.EF.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome)
                .HasMaxLength(100);

            //builder.HasMany<Cliente>()
            //    .WithOne(e => e.Area);

        }
    }
}
