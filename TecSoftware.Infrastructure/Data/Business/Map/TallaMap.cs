using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class TallaMap : IEntityTypeConfiguration<Talla>
    {
        public void Configure(EntityTypeBuilder<Talla> builder)
        {
            builder.ToTable("Tallas");
            builder.HasKey(c => c.TallaId);
            builder.Property(c => c.TallaId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(80);
        }
    }
}
