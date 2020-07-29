using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ImpuestoMap : IEntityTypeConfiguration<Impuesto>
    {
        public void Configure(EntityTypeBuilder<Impuesto> builder)
        {
            builder.ToTable("Impuestos");
            builder.HasKey(c => c.ImpuestoId);
            builder.Property(c => c.ImpuestoId).ValueGeneratedOnAdd();
            builder.Property(c => c.Codigo).HasMaxLength(2);
            builder.Property(c => c.Nombre).HasMaxLength(80);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
