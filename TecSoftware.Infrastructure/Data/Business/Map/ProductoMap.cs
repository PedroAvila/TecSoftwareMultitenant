using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(c => c.ProductoId);
            builder.Property(c => c.ProductoId).ValueGeneratedOnAdd();
            builder.Property(c => c.TipoProducto)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Codigo).HasMaxLength(13);
            builder.Property(c => c.CodigoBarra).HasMaxLength(15);
            builder.Property(c => c.Nombre).HasMaxLength(200);
            builder.HasOne(c => c.Categoria)
                .WithMany()
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.SubCategoria)
                .WithMany()
                .HasForeignKey(c => c.SubCategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Marca)
                .WithMany()
                .HasForeignKey(c => c.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Moneda)
                .WithMany()
                .HasForeignKey(c => c.MonedaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Medida)
                .WithMany()
                .HasForeignKey(c => c.MedidaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Presentacion)
                .WithMany()
                .HasForeignKey(c => c.PresentacionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Laboratorio)
                .WithMany()
                .HasForeignKey(c => c.LaboratorioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.FechaVencimiento);
            builder.Property(c => c.PrecioCompra);
            builder.Property(c => c.Lote).HasMaxLength(10);
            builder.Property(c => c.IncluyeImpuesto)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(c => c.CalculoImportePorRangos);
        }
    }
}
