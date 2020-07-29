
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.UsuarioId).ValueGeneratedOnAdd();
            builder.Property(x => x.Nombre).HasMaxLength(80);
            builder.HasOne(c => c.Rol)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(c => c.RolId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.User).HasMaxLength(15);
            builder.Property(x => x.Password).HasMaxLength(200);
            builder.Property(x => x.Foto);
            builder.Property(x => x.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
