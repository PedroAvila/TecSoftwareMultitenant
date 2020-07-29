using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoPrecioMap : IEntityTypeConfiguration<ProductoPrecio>
    {
        public void Configure(EntityTypeBuilder<ProductoPrecio> builder)
        {
            builder.ToTable("ProductoPrecios");
            builder.HasKey(c => c.ProductoPrecioId);
            builder.Property(c => c.ProductoPrecioId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.ListaPrecio)
                .WithMany(c => c.ProductoPrecios)
                .HasForeignKey(c => c.ListaPrecioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Producto)
                .WithMany(c => c.ProductoPrecios)
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.TipoPrecioId).IsRequired();
            builder.Property(c => c.PrecioCompra);
            builder.Property(c => c.CantidadMinima);
            builder.Property(c => c.CantidadMaxima);
            builder.Property(c => c.Utilidad);
            builder.Property(c => c.Pvp);
            builder.Property(c => c.ImporteMinimo);
        }
    }
}
