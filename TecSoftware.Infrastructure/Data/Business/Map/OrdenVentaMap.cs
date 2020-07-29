using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class OrdenVentaMap : IEntityTypeConfiguration<OrdenVenta>
    {
        public void Configure(EntityTypeBuilder<OrdenVenta> builder)
        {
            builder.ToTable("OrdenVentas");
            builder.HasKey(c => c.OrdenVentaId);
            builder.Property(c => c.OrdenVentaId).ValueGeneratedOnAdd();
            builder.Property(c => c.CodigoNumerico).HasMaxLength(9);
            builder.Property(c => c.NumeroComprobante).HasMaxLength(15);
            builder.Property(c => c.FechaEmision);
            builder.Property(c => c.FechaEntrega);
            builder.HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.PuntoEmision)
                .WithMany()
                .HasForeignKey(c => c.PuntoEmisionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Total);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
