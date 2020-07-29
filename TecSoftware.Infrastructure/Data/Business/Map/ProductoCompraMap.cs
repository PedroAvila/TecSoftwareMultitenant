using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoCompraMap : IEntityTypeConfiguration<ProductoCompra>
    {
        public void Configure(EntityTypeBuilder<ProductoCompra> builder)
        {
            builder.ToTable("ProductoCompras");
            builder.HasKey(c => c.ProductoCompraId);
            builder.Property(c => c.ProductoCompraId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Compra)
                .WithMany(c => c.ProductoCompras)
                .HasForeignKey(c => c.CompraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoOrdenCompra)
                .WithMany()
                .HasForeignKey(c => c.ProductoOrdenCompraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
            builder.Property(c => c.PrecioCompra);
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
