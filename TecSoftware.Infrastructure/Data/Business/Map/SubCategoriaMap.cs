using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class SubCategoriaMap : IEntityTypeConfiguration<SubCategoria>
    {
        public void Configure(EntityTypeBuilder<SubCategoria> builder)
        {
            builder.ToTable("SubCategorias");
            builder.HasKey(c => c.SubCategoriaId);
            builder.Property(c => c.SubCategoriaId).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Categoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Nombre).HasMaxLength(80);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
