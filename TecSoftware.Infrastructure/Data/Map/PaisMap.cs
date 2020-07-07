using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");
            builder.HasKey(c => c.PaisId);
            builder.Property(c => c.PaisId)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre)
                .HasMaxLength(200);
            builder.Property(c => c.Developer)
                .HasMaxLength(200);
        }
    }
}
