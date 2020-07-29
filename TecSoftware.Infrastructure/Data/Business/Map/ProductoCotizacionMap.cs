using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoCotizacionMap : IEntityTypeConfiguration<ProductoCotizacion>
    {
        public void Configure(EntityTypeBuilder<ProductoCotizacion> builder)
        {
            builder.ToTable("ProductoCotizaciones");
            builder.HasKey(c => c.ProductoCotizacionId);
            builder.Property(c => c.ProductoCotizacionId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.SolicitudCotizacion)
                .WithMany(c => c.ProductoCotizaciones)
                .HasForeignKey(c => c.SolicitudCotizacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoRequerimiento)
                .WithMany()
                .HasForeignKey(c => c.ProductoRequerimientoId)
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
            builder.Property(c => c.Precio);
            builder.Property(c => c.SubTotal);
            builder.Property(c => c.ValorTasaImpuesto);
            builder.Property(c => c.ValorIva);
            builder.Property(c => c.TotalDescuento);
        }
    }
}
