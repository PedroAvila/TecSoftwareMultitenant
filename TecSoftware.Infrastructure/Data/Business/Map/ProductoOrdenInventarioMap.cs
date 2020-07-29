using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoOrdenInventarioMap : IEntityTypeConfiguration<ProductoOrdenInventario>
    {
        public void Configure(EntityTypeBuilder<ProductoOrdenInventario> builder)
        {
            builder.ToTable("ProductoOrdenInventarios");
            builder.HasKey(c => c.ProductoOrdenInventarioId);
            builder.Property(c => c.ProductoOrdenInventarioId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.OrdenInventario)
                .WithMany(c => c.ProductoOrdenInventarios)
                .HasForeignKey(c => c.OrdenInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ConceptoInventario)
                .WithMany()
                .HasForeignKey(c => c.ConceptoInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.TipoOperacion)
                .HasConversion<int>()
                .IsRequired();
            builder.HasOne(c => c.Almacen)
                .WithMany()
                .HasForeignKey(c => c.AlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
            builder.Property(c => c.PrecioUnitario);
        }
    }
}
