using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class MedidaMap : IEntityTypeConfiguration<Medida>
    {
        public void Configure(EntityTypeBuilder<Medida> builder)
        {
            builder.ToTable("Medidas");
            builder.HasKey(c => c.MedidaId);
            builder.Property(c => c.MedidaId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(60);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
