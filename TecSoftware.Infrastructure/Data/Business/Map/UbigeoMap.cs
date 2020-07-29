using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class UbigeoMap : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeos");
            builder.HasKey(c => c.UbigeoId);
            builder.Property(c => c.UbigeoId).ValueGeneratedOnAdd();
            builder.Property(c => c.CodigoProvincia).HasMaxLength(2);
            builder.Property(c => c.Provincia).HasMaxLength(100);
            builder.Property(c => c.CodigoCanton).HasMaxLength(4);
            builder.Property(c => c.Canton).HasMaxLength(100);
            builder.Property(c => c.CodigoParroquia).HasMaxLength(6);
            builder.Property(c => c.Parroquia).HasMaxLength(100);
        }
    }
}
