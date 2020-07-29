using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ImpuestoVentaMap : IEntityTypeConfiguration<ImpuestoVenta>
    {
        public void Configure(EntityTypeBuilder<ImpuestoVenta> builder)
        {
            builder.ToTable("ImpuestoVentas");
            builder.HasKey(c => c.ImpuestoVentaId);
            builder.Property(c => c.ImpuestoVentaId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.DetaaComprobantePago)
                .WithMany(c => c.ImpuestoVentas)
                .HasForeignKey(c => c.DetalleComprobantePagoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.TasaImpuesto)
                .WithMany(c => c.ImpuestoVentas)
                .HasForeignKey(c => c.TasaImpuestoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
