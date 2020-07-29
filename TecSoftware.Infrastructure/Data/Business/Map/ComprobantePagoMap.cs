using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ComprobantePagoMap : IEntityTypeConfiguration<ComprobantePago>
    {
        public void Configure(EntityTypeBuilder<ComprobantePago> builder)
        {
            builder.ToTable("ComprobantePagos");
            builder.HasKey(c => c.ComprobantePagoId);
            builder.Property(c => c.ComprobantePagoId).ValueGeneratedOnAdd();
            builder.Property(c => c.CodigoNumerico).IsRequired().HasMaxLength(8);
            builder.Property(c => c.NumeroComprobante).IsRequired().HasMaxLength(15);
            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.ComprobantePagos)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaEmision);
            builder.Property(c => c.DigitoVerificador);
            builder.HasOne(c => c.PuntoEmision)
                .WithMany(c => c.ComprobantePagos)
                .HasForeignKey(c => c.PuntoEmisionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Comprobante)
                .WithMany(c => c.ComprobantePagos)
                .HasForeignKey(c => c.ComprobanteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.TipoIdentificacion)
                .WithMany(c => c.ComprobantePagos)
                .HasForeignKey(c => c.TipoIdentificacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.FormaPago)
                .WithMany(c => c.ComprobantePagos)
                .HasForeignKey(c => c.FormaPagoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.EstadoComprobanteElectronico)
                .WithMany()
                .HasForeignKey(c => c.EstadoCe);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Total);
        }
    }
}
