using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoCotizacionProveedorMap : IEntityTypeConfiguration<ProductoCotizacionProveedor>
    {
        public void Configure(EntityTypeBuilder<ProductoCotizacionProveedor> builder)
        {
            builder.ToTable("ProductoCotizacionProveedores");
            builder.HasKey(c => c.ProductoCotizacionProveedorId);
            builder.Property(c => c.ProductoCotizacionProveedorId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.CotizacionProveedor)
                .WithMany(c => c.ProductoCotizacionProveedores)
                .HasForeignKey(c => c.CotizacionProveedorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoCotizacion)
                .WithMany()
                .HasForeignKey(c => c.ProductoCotizacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FormaPago)
                .HasConversion<int>()
                .IsRequired();
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
            builder.HasOne(c => c.Medida)
                .WithMany()
                .HasForeignKey(c => c.MedidaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.PrecioCompra);
            builder.Property(c => c.TasaImpuesto);
            builder.Property(c => c.SubTotal);
            builder.Property(c => c.ValorIva);
        }
    }
}
