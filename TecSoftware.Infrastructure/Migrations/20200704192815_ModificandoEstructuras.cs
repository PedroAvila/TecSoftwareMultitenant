using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecSoftware.Infrastructure.Migrations
{
    public partial class ModificandoEstructuras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatabaseConnectionString",
                table: "Inquilinos");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Inquilinos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Inquilinos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Inquilinos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Inquilinos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "BaseDatos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatabaseConnectionString",
                table: "BaseDatos",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Developer = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Prueba",
                columns: table => new
                {
                    PruebaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prueba", x => x.PruebaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Prueba");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "DatabaseConnectionString",
                table: "BaseDatos");

            migrationBuilder.AddColumn<string>(
                name: "DatabaseConnectionString",
                table: "Inquilinos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "BaseDatos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
