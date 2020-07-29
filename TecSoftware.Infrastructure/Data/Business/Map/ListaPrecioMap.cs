using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ListaPrecioMap : IEntityTypeConfiguration<ListaPrecio>
    {
        public void Configure(EntityTypeBuilder<ListaPrecio> builder)
        {
            builder.ToTable("ListaPrecios");
            builder.HasKey(c => c.ListaPrecioId);
            builder.Property(c => c.ListaPrecioId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(200);
            builder.Property(c => c.FechaInicio);
            builder.Property(c => c.FechaFin);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
