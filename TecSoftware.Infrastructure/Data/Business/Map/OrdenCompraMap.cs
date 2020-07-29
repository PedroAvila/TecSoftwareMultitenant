using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class OrdenCompraMap : IEntityTypeConfiguration<OrdenCompra>
    {
        public void Configure(EntityTypeBuilder<OrdenCompra> builder)
        {
            builder.ToTable("OrdenCompras");
            builder.HasKey(c => c.OrdenCompraId);
            builder.Property(c => c.OrdenCompraId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Proveedor)
                .WithMany()
                .HasForeignKey(c => c.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaEmision);
            builder.Property(c => c.FechaEntrega);
            builder.Property(c => c.DireccionEntrega).HasMaxLength(150);
            builder.Property(c => c.FormaPago)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.NumeroOrden).HasMaxLength(10);
            builder.Property(c => c.EstadoOrdenCompra)
                .HasConversion<int>()
                .IsRequired();
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Total);
        }
    }
}
