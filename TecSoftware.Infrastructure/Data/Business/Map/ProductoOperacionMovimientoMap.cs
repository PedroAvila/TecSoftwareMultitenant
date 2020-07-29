using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoOperacionMovimientoMap : IEntityTypeConfiguration<ProductoOperacionMovimiento>
    {
        public void Configure(EntityTypeBuilder<ProductoOperacionMovimiento> builder)
        {
            builder.ToTable("ProductoOperacionMovimientos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.OperacionMovimiento)
                .WithMany(c => c.ProductoOperacionMovimientos)
                .HasForeignKey(c => c.OperacionMovimientoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoOrdenInventario)
                .WithMany()
                .HasForeignKey(c => c.ProductoOrdenInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
        }
    }
}
