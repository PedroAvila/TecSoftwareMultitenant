using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.HasKey(c => c.CompraId);
            builder.Property(c => c.CompraId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Proveedor)
                .WithMany()
                .HasForeignKey(c => c.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaCompra);
            builder.Property(c => c.NumeroFactura).HasMaxLength(10);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Total);
            builder.Property(c => c.EstadoCompra)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
