using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.ClienteId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.TipoIdentificacion)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.TipoIdentificacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Numero).HasMaxLength(20);
            builder.Property(c => c.RazonSocial).HasMaxLength(300);
            builder.Property(c => c.Direccion).HasMaxLength(300);
            builder.Property(c => c.Telefono).HasMaxLength(10);
            builder.Property(c => c.Email).HasMaxLength(100);
        }
    }
}
