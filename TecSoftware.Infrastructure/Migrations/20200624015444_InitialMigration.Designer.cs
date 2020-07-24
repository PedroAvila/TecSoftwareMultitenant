﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TecSoftware.Infrastructure.Data.Catalogo;

namespace TecSoftware.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogoInquilinoContext))]
    [Migration("20200624015444_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TecSoftware.Core.BaseDato", b =>
                {
                    b.Property<int>("BaseDatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("InquilinoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ServidorId")
                        .HasColumnType("int");

                    b.HasKey("BaseDatoId");

                    b.HasIndex("ServidorId");

                    b.ToTable("BaseDatos");
                });

            modelBuilder.Entity("TecSoftware.Core.Inquilino", b =>
                {
                    b.Property<int>("InquilinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PlanServicio")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("InquilinoId");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("TecSoftware.Core.Servidor", b =>
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

            modelBuilder.Entity("TecSoftware.Core.BaseDato", b =>
                {
                    b.HasOne("TecSoftware.Core.Servidor", "Servidor")
                        .WithMany("BaseDatos")
                        .HasForeignKey("ServidorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TecSoftware.Core.Inquilino", b =>
                {
                    b.HasOne("TecSoftware.Core.BaseDato", "BaseDato")
                        .WithOne("Inquilino")
                        .HasForeignKey("TecSoftware.Core.Inquilino", "InquilinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
