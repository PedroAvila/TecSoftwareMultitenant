using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class OrdenInventarioMap : IEntityTypeConfiguration<OrdenInventario>
    {
        public void Configure(EntityTypeBuilder<OrdenInventario> builder)
        {
            builder.ToTable("OrdenInventarios");
            builder.HasKey(c => c.OrdenInventarioId);
            builder.Property(c => c.OrdenInventarioId).ValueGeneratedOnAdd();
            builder.Property(c => c.NumeroOrden).HasMaxLength(10);
            builder.Property(c => c.Fecha);
            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.EstadoOrden)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
