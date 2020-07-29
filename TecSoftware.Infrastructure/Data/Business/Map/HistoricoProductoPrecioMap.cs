using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class HistoricoProductoPrecioMap : IEntityTypeConfiguration<HistoricoProductoPrecio>
    {
        public void Configure(EntityTypeBuilder<HistoricoProductoPrecio> builder)
        {
            builder.ToTable("HistoricoProductoPrecios");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.ProductoPrecio)
                .WithMany()
                .HasForeignKey(c => c.ProductoPrecioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.CantidadMinima);
            builder.Property(c => c.CantidadMaxima);
            builder.Property(c => c.TipoPrecioId);
            builder.Property(c => c.PrecioCompra);
            builder.Property(c => c.Utilidad);
            builder.Property(c => c.Pvp);
            builder.Property(c => c.FechaUpdate);
        }
    }
}
