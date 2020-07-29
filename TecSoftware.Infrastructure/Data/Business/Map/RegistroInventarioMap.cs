using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class RegistroInventarioMap : IEntityTypeConfiguration<RegistroInventario>
    {
        public void Configure(EntityTypeBuilder<RegistroInventario> builder)
        {
            builder.ToTable("RegistroInventarios");
            builder.HasKey(c => c.RegistroInventarioId);
            builder.Property(c => c.RegistroInventarioId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.OperacionMovimiento)
                .WithMany(c => c.RegistroInventarios)
                .HasForeignKey(c => c.OperacionMovimientoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.TipoRegistroInventario)
                .HasConversion<int>()
                .IsRequired();
            builder.HasOne(c => c.Almacen)
                .WithMany()
                .HasForeignKey(c => c.AlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaOperacion);
        }
    }
}
