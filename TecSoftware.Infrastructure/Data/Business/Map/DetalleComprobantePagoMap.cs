using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class DetalleComprobantePagoMap : IEntityTypeConfiguration<DetalleComprobantePago>
    {
        public void Configure(EntityTypeBuilder<DetalleComprobantePago> builder)
        {
            builder.ToTable("DetalleComprobantePagos");
            builder.HasKey(c => c.DetalleComprobantePagoId);
            builder.Property(c => c.DetalleComprobantePagoId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.ComprobantePago)
                .WithMany(c => c.DetalleComprobantePagos)
                .HasForeignKey(c => c.ComprobantePagoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.DetalleOrdenVenta)
                .WithMany()
                .HasForeignKey(c => c.DetalleOrdenVentaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoPrecio)
                .WithMany()
                .HasForeignKey(c => c.ProductoPrecioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.SubTotalIva);
            builder.Property(c => c.SubTotalCero);
            builder.Property(c => c.SubTotalNoObjetoIva);
            builder.Property(c => c.SubTotalExentoIva);
            builder.Property(c => c.SubTotal);
            builder.Property(c => c.TotalDescuento);
            builder.Property(c => c.ValorIce);
            builder.Property(c => c.ValorIrbpnr);
            builder.Property(c => c.ValorIva);
            builder.Property(c => c.Propina);
        }
    }
}
