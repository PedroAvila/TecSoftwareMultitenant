using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class RecuentoMap : IEntityTypeConfiguration<Recuento>
    {
        public void Configure(EntityTypeBuilder<Recuento> builder)
        {
            builder.ToTable("Recuentos");
            builder.HasKey(c => c.RecuentoId);
            builder.Property(c => c.RecuentoId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Operacion)
                .WithMany(c => c.Recuentos)
                .HasForeignKey(c => c.OperacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Denominacion)
                .WithMany()
                .HasForeignKey(c => c.DenominacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Cantidad);
        }
    }
}
