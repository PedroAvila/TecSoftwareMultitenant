using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoAlmacenMap : IEntityTypeConfiguration<ProductoAlmacen>
    {
        public void Configure(EntityTypeBuilder<ProductoAlmacen> builder)
        {
            builder.ToTable("ProductoAlmacenes");
            builder.HasKey(c => c.ProductoAlmacenId);
            builder.Property(c => c.ProductoAlmacenId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Almacen)
                .WithMany(c => c.ProductoAlmacenes)
                .HasForeignKey(c => c.AlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Producto)
                .WithMany()
                .HasForeignKey(c => c.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.SaldoMinimo);
            builder.Property(c => c.SaldoMaximo);
            builder.Property(c => c.Saldo);
        }
    }
}
