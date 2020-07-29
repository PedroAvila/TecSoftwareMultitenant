using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class EstablecimientoMap : IEntityTypeConfiguration<Establecimiento>
    {
        public void Configure(EntityTypeBuilder<Establecimiento> builder)
        {
            builder.ToTable("Establecimientos");
            builder.HasKey(c => c.EstablecimientoId);
            builder.Property(c => c.EstablecimientoId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Empresa)
                .WithMany(c => c.Establecimientos)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Codigo).HasMaxLength(3);
            builder.Property(c => c.Nombre).HasMaxLength(120);
            builder.Property(c => c.Direccion).HasMaxLength(200);
            builder.Property(c => c.TelefonoFijo).HasMaxLength(10);
            builder.Property(c => c.TelefonoCelular).HasMaxLength(10);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
