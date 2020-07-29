using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ConceptoInventarioMap : IEntityTypeConfiguration<ConceptoInventario>
    {
        public void Configure(EntityTypeBuilder<ConceptoInventario> builder)
        {
            builder.ToTable("ConceptoInventarios");
            builder.HasKey(c => c.ConceptoInventarioId);
            builder.Property(c => c.ConceptoInventarioId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.TipoOperacion)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
