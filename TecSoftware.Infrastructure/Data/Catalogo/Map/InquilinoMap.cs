﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Catalogo
{
    public class InquilinoMap : IEntityTypeConfiguration<Inquilino>
    {
        public void Configure(EntityTypeBuilder<Inquilino> builder)
        {
            builder.ToTable("Inquilinos");
            builder.HasKey(c => c.InquilinoId);
            builder.Property(c => c.InquilinoId)
                .ValueGeneratedOnAdd();
            builder.HasOne(c => c.BaseDato)
                .WithOne(c => c.Inquilino)
                .HasForeignKey<BaseDato>(c => c.BaseDatoOfInquilinoId);
            builder.Property(c => c.Nombre).HasMaxLength(100);
            builder.Property(c => c.Dominio).HasMaxLength(500);
            builder.Property(c => c.PlanServicio).HasMaxLength(200);
            builder.Property(c => c.FechaCreacion);
            builder.Property(c => c.FechaInicio);
            builder.Property(c => c.FechaFin);
            builder.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
