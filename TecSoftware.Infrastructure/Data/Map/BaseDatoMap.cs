using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data
{
    public class BaseDatoMap : IEntityTypeConfiguration<BaseDato>
    {
        public void Configure(EntityTypeBuilder<BaseDato> builder)
        {
            builder.ToTable("BaseDatos");
            builder.HasKey(c => c.BaseDatoId);
            builder.Property(c => c.BaseDatoId)
                .ValueGeneratedOnAdd();
            builder.HasOne(c => c.Servidor)
                .WithMany(c => c.BaseDatos)
                .HasForeignKey(c => c.ServidorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Inquilino)
                .WithOne(c => c.BaseDato)
                .HasForeignKey<BaseDato>(c => c.BaseDatoOfInquilinoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Nombre)
                .HasMaxLength(100);
            builder.Property(c => c.Estado)
                .HasMaxLength(100);
        }
    }
}
