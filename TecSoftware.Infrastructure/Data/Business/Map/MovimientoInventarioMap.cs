using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class MovimientoInventarioMap : IEntityTypeConfiguration<MovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
        {
            builder.ToTable("MovimientoInventarios");
            builder.HasKey(c => c.MovimientoInventarioId);
            builder.Property(c => c.MovimientoInventarioId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.ProductoAlmacen)
                .WithMany()
                .HasForeignKey(c => c.ProductoAlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoOperacionMovimiento)
                .WithMany()
                .HasForeignKey(c => c.ProductoOperacionMovimientoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ProductoRegistroInventario)
                .WithMany()
                .HasForeignKey(c => c.ProductoRegistroInventarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaOperacionInventario);
            builder.Property(c => c.CantidadSaldoInicial);
            builder.Property(c => c.CostoUnitarioSaldoInicial);
            builder.Property(c => c.CostoTotalSaldoInical);
            builder.Property(c => c.CantidadEntrada);
            builder.Property(c => c.CostoUnitarioEntrada);
            builder.Property(c => c.CostoTotalEntrada);
            builder.Property(c => c.CantidadSalida);
            builder.Property(c => c.CostoUnitarioSalida);
            builder.Property(c => c.CostoTotalSalida);
            builder.Property(c => c.CantidadSaldoFinal);
            builder.Property(c => c.CostoUnitarioSaldoFinal);
            builder.Property(c => c.CostoTotalSaldoFinal);
        }
    }
}
