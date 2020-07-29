using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class OperacionMap : IEntityTypeConfiguration<Operacion>
    {
        public void Configure(EntityTypeBuilder<Operacion> builder)
        {
            builder.ToTable("Operaciones");
            builder.HasKey(c => c.OperacionId);
            builder.Property(c => c.OperacionId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.PuntoEmision)
                .WithMany()
                .HasForeignKey(c => c.PuntoEmisionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaApertura);
            builder.Property(c => c.FechaCierre);
        }
    }
}
