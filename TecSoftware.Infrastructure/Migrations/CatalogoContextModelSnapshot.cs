﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TecSoftware.Infrastructure.Data.Catalogo;

namespace TecSoftware.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogoContext))]
    partial class CatalogoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TecSoftware.EntidadesDominio.BaseDato", b =>
                {
                    b.Property<int>("BaseDatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseDatoOfInquilinoId")
                        .HasColumnType("int");

                    b.Property<string>("DatabaseConnectionString")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ServidorId")
                        .HasColumnType("int");

                    b.HasKey("BaseDatoId");

                    b.HasIndex("BaseDatoOfInquilinoId")
                        .IsUnique();

                    b.HasIndex("ServidorId");

                    b.ToTable("BaseDatos");
                });

            modelBuilder.Entity("TecSoftware.EntidadesDominio.Inquilino", b =>
                {
                    b.Property<int>("InquilinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dominio")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PlanServicio")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("InquilinoId");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("TecSoftware.EntidadesDominio.Servidor", b =>
                {
                    b.Property<int>("ServidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("ServidorId");

                    b.ToTable("Servidores");
                });

            modelBuilder.Entity("TecSoftware.EntidadesDominio.BaseDato", b =>
                {
                    b.HasOne("TecSoftware.EntidadesDominio.Inquilino", "Inquilino")
                        .WithOne("BaseDato")
                        .HasForeignKey("TecSoftware.EntidadesDominio.BaseDato", "BaseDatoOfInquilinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TecSoftware.EntidadesDominio.Servidor", "Servidor")
                        .WithMany("BaseDatos")
                        .HasForeignKey("ServidorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
