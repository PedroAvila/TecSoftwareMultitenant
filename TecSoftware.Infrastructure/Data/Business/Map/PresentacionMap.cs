using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class PresentacionMap : IEntityTypeConfiguration<Presentacion>
    {
        public void Configure(EntityTypeBuilder<Presentacion> builder)
        {
            builder.ToTable("Presentaciones");
            builder.HasKey(c => c.PresentacionId);
            builder.Property(c => c.PresentacionId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Medida)
                .WithMany(c => c.Presentaciones)
                .HasForeignKey(c => c.MedidaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Nombre).HasMaxLength(80);
            builder.Property(c => c.Abreviacion).HasMaxLength(50);
            builder.Property(c => c.Equivalencia);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
