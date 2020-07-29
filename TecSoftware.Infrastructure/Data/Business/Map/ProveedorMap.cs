using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProveedorMap : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");
            builder.HasKey(c => c.ProveedorId);
            builder.Property(c => c.ProveedorId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.TipoIdentificacion)
                .WithMany()
                .HasForeignKey(c => c.TipoIdentificacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Numero).HasMaxLength(18);
            builder.Property(c => c.RazonSocial).HasMaxLength(100);
            builder.Property(c => c.Representante).HasMaxLength(100);
            builder.Property(c => c.Direccion).HasMaxLength(100);
            builder.Property(c => c.Telefono).HasMaxLength(10);
            builder.Property(c => c.EmailProveedor).HasMaxLength(80);
            builder.Property(c => c.EmailVendedor).HasMaxLength(80);
            builder.HasOne(c => c.Ubigeo)
                .WithMany()
                .HasForeignKey(c => c.UbigeoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
