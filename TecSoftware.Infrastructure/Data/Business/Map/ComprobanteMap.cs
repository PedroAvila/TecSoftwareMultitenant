using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ComprobanteMap : IEntityTypeConfiguration<Comprobante>
    {
        public void Configure(EntityTypeBuilder<Comprobante> builder)
        {
            builder.ToTable("Comprobantes");
            builder.HasKey(c => c.ComprobanteId);
            builder.Property(c => c.ComprobanteId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Codigo).HasMaxLength(2);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
