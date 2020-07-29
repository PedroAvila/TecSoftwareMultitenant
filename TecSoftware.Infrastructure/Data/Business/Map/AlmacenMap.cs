using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class AlmacenMap : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.ToTable("Almacenes");
            builder.HasKey(c => c.AlmacenId);
            builder.Property(c => c.AlmacenId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Establecimiento)
                .WithMany(c => c.Almacenes)
                .HasForeignKey(c => c.EstablecimientoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Nombre).HasMaxLength(80);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
