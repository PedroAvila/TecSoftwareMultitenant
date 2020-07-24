using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(c => c.EmpresaId);
            builder.Property(c => c.EmpresaId).ValueGeneratedOnAdd();
            builder.Property(c => c.Ruc).HasMaxLength(13);
            builder.Property(c => c.RazonSocial).HasMaxLength(300);
            builder.Property(c => c.Direccion).HasMaxLength(300);
            builder.Property(c => c.TelefonoFijo).HasMaxLength(10);
            builder.Property(c => c.TelefonoCelular).HasMaxLength(10);
            builder.Property(c => c.Representante).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.ClaveEmail).HasMaxLength(30);
            builder.Property(c => c.ObligadoContabilidad);
            builder.Property(c => c.Emision);
            builder.Property(c => c.Ambiente).IsRequired();
            builder.Property(c => c.LogoEmisor);
        }
    }
}
