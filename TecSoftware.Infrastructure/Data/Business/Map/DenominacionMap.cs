using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class DenominacionMap : IEntityTypeConfiguration<Denominacion>
    {
        public void Configure(EntityTypeBuilder<Denominacion> builder)
        {
            builder.ToTable("Denominaciones");
            builder.HasKey(c => c.DenominacionId);
            builder.Property(c => c.DenominacionId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(80);
            builder.Property(c => c.Valor);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
