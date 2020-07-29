using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class PuntoEmisionMap : IEntityTypeConfiguration<PuntoEmision>
    {
        public void Configure(EntityTypeBuilder<PuntoEmision> builder)
        {
            builder.ToTable("PuntoEmisiones");
            builder.HasKey(c => c.PuntoEmisionId);
            builder.Property(c => c.PuntoEmisionId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Establecimiento)
                .WithMany(c => c.PuntoEmisiones)
                .HasForeignKey(c => c.EstablecimientoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.EstablecimientoId).IsRequired();
            builder.Property(c => c.Codigo).HasMaxLength(3);
            builder.Property(c => c.Nombre).HasMaxLength(120);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
