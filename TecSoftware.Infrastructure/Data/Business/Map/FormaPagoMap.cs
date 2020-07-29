using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class FormaPagoMap : IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder)
        {
            builder.ToTable("FormaPagos");
            builder.HasKey(c => c.FormaPagoId);
            builder.Property(c => c.FormaPagoId).ValueGeneratedOnAdd();
            builder.Property(c => c.Codigo).HasMaxLength(2);
            builder.Property(c => c.Nombre).HasMaxLength(200);
        }
    }
}
