using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ColorMap : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.ToTable("Colores");
            builder.HasKey(c => c.ColorId);
            builder.Property(c => c.ColorId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(80);
        }
    }
}
