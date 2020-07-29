using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class AreaNegocioMap : IEntityTypeConfiguration<AreaNegocio>
    {
        public void Configure(EntityTypeBuilder<AreaNegocio> builder)
        {
            builder.ToTable("AreaNegocios");
            builder.HasKey(c => c.AreaNegocioId);
            builder.Property(c => c.AreaNegocioId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(200);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
