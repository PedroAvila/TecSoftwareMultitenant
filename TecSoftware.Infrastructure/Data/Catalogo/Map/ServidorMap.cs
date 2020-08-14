using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Catalogo
{
    public class ServidorMap : IEntityTypeConfiguration<Servidor>
    {
        public void Configure(EntityTypeBuilder<Servidor> builder)
        {
            builder.HasKey(c => c.ServidorId);
            builder.Property(c => c.ServidorId)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre)
                .HasMaxLength(200);
            builder.Property(c => c.Ubicacion)
                .HasMaxLength(200);
            builder.Property(c => c.Estado)
                .HasMaxLength(200);
        }
    }
}
