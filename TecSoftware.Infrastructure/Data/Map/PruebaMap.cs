using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data
{
    public class PruebaMap : IEntityTypeConfiguration<Prueba>
    {
        public void Configure(EntityTypeBuilder<Prueba> builder)
        {
            builder.ToTable("Prueba");
            builder.HasKey(c => c.PruebaId);
            builder.Property(c => c.PruebaId)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre)
                .HasMaxLength(500);
        }
    }
}
