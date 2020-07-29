using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoRegistroInventarioMap : IEntityTypeConfiguration<ProductoRegistroInventario>
    {
        public void Configure(EntityTypeBuilder<ProductoRegistroInventario> builder)
        {
            builder.ToTable("ProductoRegistroInventarios");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.RegistroInventario)
                .WithMany(c => c.ProductoRegistroInventarios)
                .HasForeignKey(c => c.RegistroInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoOrdenInventario)
                .WithMany()
                .HasForeignKey(c => c.ProductoOrdenInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
        }
    }
}
