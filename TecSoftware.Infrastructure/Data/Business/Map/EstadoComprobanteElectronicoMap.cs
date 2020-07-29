using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class EstadoComprobanteElectronicoMap : IEntityTypeConfiguration<EstadoComprobanteElectronico>
    {
        public void Configure(EntityTypeBuilder<EstadoComprobanteElectronico> builder)
        {
            builder.ToTable("EstadoComprobanteElectronicos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Descripcion).HasMaxLength(100);
            builder.Property(c => c.Siglas).HasMaxLength(50);
        }
    }
}
