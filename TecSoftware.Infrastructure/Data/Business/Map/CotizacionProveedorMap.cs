using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class CotizacionProveedorMap : IEntityTypeConfiguration<CotizacionProveedor>
    {
        public void Configure(EntityTypeBuilder<CotizacionProveedor> builder)
        {
            builder.ToTable("CotizacionProveedores");
            builder.HasKey(c => c.CotizacionProveedorId);
            builder.Property(c => c.CotizacionProveedorId).ValueGeneratedOnAdd();
            builder.Property(c => c.NumeroCotizacion).HasMaxLength(10);
            builder.Property(c => c.FechaInicio);
            builder.Property(c => c.FechaFin);
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
