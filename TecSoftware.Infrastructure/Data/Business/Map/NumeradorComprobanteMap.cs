using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class NumeradorComprobanteMap : IEntityTypeConfiguration<NumeradorComprobante>
    {
        public void Configure(EntityTypeBuilder<NumeradorComprobante> builder)
        {
            builder.ToTable("NumeradorComprobantes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.PuntoEmision)
                .WithMany()
                .HasForeignKey(c => c.PuntoEmisionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Comprobante)
                .WithMany()
                .HasForeignKey(c => c.ComprobanteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Serie).HasMaxLength(6);
            builder.Property(c => c.Secuencial).HasMaxLength(9);
            builder.Property(c => c.Impresora).HasMaxLength(50);
        }
    }
}
