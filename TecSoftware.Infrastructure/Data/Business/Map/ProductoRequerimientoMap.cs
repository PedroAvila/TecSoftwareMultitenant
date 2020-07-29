using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoRequerimientoMap : IEntityTypeConfiguration<ProductoRequerimiento>
    {
        public void Configure(EntityTypeBuilder<ProductoRequerimiento> builder)
        {
            builder.ToTable("ProductoRequerimientos");
            builder.HasKey(c => c.ProductoRequerimientoId);
            builder.Property(c => c.ProductoRequerimientoId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.RequerimientoCompra)
                .WithMany(c => c.ProductoRequerimientos)
                .HasForeignKey(c => c.RequerimientoCompraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.AreaNegocio)
                .WithMany()
                .HasForeignKey(c => c.AreaNegocioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Medida)
                .WithMany()
                .HasForeignKey(c => c.MedidaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
        }
    }
}
