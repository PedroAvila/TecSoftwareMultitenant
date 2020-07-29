using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoOrdenCompraMap : IEntityTypeConfiguration<ProductoOrdenCompra>
    {
        public void Configure(EntityTypeBuilder<ProductoOrdenCompra> builder)
        {
            builder.ToTable("ProductoOrdenCompras");
            builder.HasKey(c => c.ProductoOrdenCompraId);
            builder.Property(c => c.ProductoOrdenCompraId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Medida)
                .WithMany()
                .HasForeignKey(c => c.MedidaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Impuesto)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Cantidad);
            builder.Property(c => c.PrecioUnitario);
            builder.Property(c => c.SubTotalIva);
            builder.Property(c => c.SubTotalCero);
            builder.Property(c => c.SubTotalNoObjetoIva);
            builder.Property(c => c.SubTotalExcentoIva);
            builder.Property(c => c.SubTotal);
            builder.Property(c => c.TotalDescuento);
            builder.Property(c => c.ValorIva);
        }
    }
}
