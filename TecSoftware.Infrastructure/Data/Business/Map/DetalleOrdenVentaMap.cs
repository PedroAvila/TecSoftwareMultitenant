using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class DetalleOrdenVentaMap : IEntityTypeConfiguration<DetalleOrdenVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleOrdenVenta> builder)
        {
            builder.ToTable("DetalleOrdenVentas");
            builder.HasKey(c => c.DetalleOrdenVentaId);
            builder.Property(c => c.DetalleOrdenVentaId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.OrdenVenta)
                .WithMany(c => c.DetalleOrdenVentas)
                .HasForeignKey(c => c.OrdenVentaId)
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
        }
    }
}
