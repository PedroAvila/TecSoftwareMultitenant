using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class FuncionMap : IEntityTypeConfiguration<Funcion>
    {
        public void Configure(EntityTypeBuilder<Funcion> builder)
        {
            builder.ToTable("Funciones");
            builder.HasKey(c => c.FuncionId);
            builder.Property(c => c.FuncionId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(100);
        }
    }
}
