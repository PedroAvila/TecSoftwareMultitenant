using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class TasaImpuestoMap : IEntityTypeConfiguration<TasaImpuesto>
    {
        public void Configure(EntityTypeBuilder<TasaImpuesto> builder)
        {
            builder.ToTable("TasaImpuestos");
            builder.HasKey(c => c.TasaImpuestoId);
            builder.Property(c => c.TasaImpuestoId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Impuesto)
                .WithMany(c => c.TasaImpuestos)
                .HasForeignKey(c => c.ImpuestoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Codigo).HasMaxLength(4).IsRequired();
            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Concepto).HasMaxLength(500);
            builder.Property(c => c.Tasa);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
