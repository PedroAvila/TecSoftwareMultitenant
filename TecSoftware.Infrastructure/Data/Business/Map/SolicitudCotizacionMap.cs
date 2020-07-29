using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class SolicitudCotizacionMap : IEntityTypeConfiguration<SolicitudCotizacion>
    {
        public void Configure(EntityTypeBuilder<SolicitudCotizacion> builder)
        {
            builder.ToTable("SolicitudCotizaciones");
            builder.HasKey(c => c.SolicitudCotizacionId);
            builder.Property(c => c.SolicitudCotizacionId).ValueGeneratedOnAdd();
            builder.Property(c => c.NumeroCotizacion).HasMaxLength(10);
            builder.Property(c => c.FechaEmision);
            builder.Property(c => c.FechaEntrega);
            builder.HasOne(c => c.Proveedor)
                .WithMany()
                .HasForeignKey(c => c.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Total);
        }
    }
}
