using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");
            builder.HasKey(c => c.MarcaId);
            builder.Property(c => c.MarcaId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(100);
        }
    }
}
