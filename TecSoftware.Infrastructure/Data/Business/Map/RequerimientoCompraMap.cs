using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class RequerimientoCompraMap : IEntityTypeConfiguration<RequerimientoCompra>
    {
        public void Configure(EntityTypeBuilder<RequerimientoCompra> builder)
        {
            builder.ToTable("RequerimientoCompras");
            builder.HasKey(c => c.RequerimientoCompraId);
            builder.Property(c => c.RequerimientoCompraId).ValueGeneratedOnAdd();
            builder.Property(c => c.NumeroRequerimiento).HasMaxLength(10);
            builder.Property(c => c.FechaEmision);
            builder.Property(c => c.FechaEntrega);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
