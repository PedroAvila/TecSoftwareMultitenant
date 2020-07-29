using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class LaboratorioMap : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            builder.ToTable("Laboratorios");
            builder.HasKey(c => c.LaboratorioId);
            builder.Property(c => c.LaboratorioId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Representante).HasMaxLength(100);
            builder.Property(c => c.Direccion).HasMaxLength(100);
            builder.Property(c => c.Telefono).HasMaxLength(10);
            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
