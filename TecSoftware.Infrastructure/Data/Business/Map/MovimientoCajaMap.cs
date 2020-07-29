using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class MovimientoCajaMap : IEntityTypeConfiguration<MovimientoCaja>
    {
        public void Configure(EntityTypeBuilder<MovimientoCaja> builder)
        {
            builder.ToTable("MovimientoCajas");
            builder.HasKey(c => c.MovimientoCajaId);
            builder.Property(c => c.MovimientoCajaId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Operacion)
                .WithMany(c => c.MovimientoCajas)
                .HasForeignKey(c => c.OperacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ComprobantePago)
                .WithMany()
                .HasForeignKey(c => c.ComprobantePagoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.TipoMovimiento)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Fecha);
            builder.Property(c => c.Concepto).HasMaxLength(500);
            builder.Property(c => c.MontoInicial);
            builder.Property(c => c.Ingreso);
            builder.Property(c => c.Egreso);
            builder.Property(c => c.Saldo);
        }
    }
}
