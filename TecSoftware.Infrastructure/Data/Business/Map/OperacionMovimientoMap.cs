using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class OperacionMovimientoMap : IEntityTypeConfiguration<OperacionMovimiento>
    {
        public void Configure(EntityTypeBuilder<OperacionMovimiento> builder)
        {
            builder.ToTable("OperacionMovimientos");
            builder.HasKey(c => c.OperacionMovimientoId);
            builder.Property(c => c.OperacionMovimientoId).ValueGeneratedOnAdd();
            builder.Property(c => c.EstadoOperacion)
                .HasConversion<int>()
                .IsRequired();
            builder.HasOne(c => c.Almacen)
                .WithMany(c => c.OperacionMovimientos)
                .HasForeignKey(c => c.AlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Fecha);
            builder.Property(c => c.TipoOperacion)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Referencia).HasMaxLength(20);
        }
    }
}
