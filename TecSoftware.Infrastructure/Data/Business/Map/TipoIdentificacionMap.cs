using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class TipoIdentificacionMap : IEntityTypeConfiguration<TipoIdentificacion>
    {
        public void Configure(EntityTypeBuilder<TipoIdentificacion> builder)
        {
            builder.ToTable("TipoIdentificaciones");
            builder.HasKey(c => c.TipoIdentificacionId);
            builder.Property(c => c.TipoIdentificacionId).ValueGeneratedOnAdd();
            builder.Property(c => c.Codigo).HasMaxLength(2);
            builder.Property(c => c.Nombre).HasMaxLength(200);
        }
    }
}
