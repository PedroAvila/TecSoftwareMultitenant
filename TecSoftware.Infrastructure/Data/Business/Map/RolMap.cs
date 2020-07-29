using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(c => c.RolId);
            builder.Property(c => c.RolId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(80);
        }
    }
}
