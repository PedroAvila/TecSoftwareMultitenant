using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecSoftware.Infrastructure.Migrations
{
    public partial class initCatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquilinos",
                columns: table => new
                {
                    InquilinoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Dominio = table.Column<string>(maxLength: 500, nullable: true),
                    PlanServicio = table.Column<string>(maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.InquilinoId);
                });

            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    ServidorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Ubicacion = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.ServidorId);
                });

            migrationBuilder.CreateTable(
                name: "BaseDatos",
                columns: table => new
                {
                    BaseDatoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServidorId = table.Column<int>(nullable: false),
                    BaseDatoOfInquilinoId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    DatabaseConnectionString = table.Column<string>(maxLength: 300, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDatos", x => x.BaseDatoId);
                    table.ForeignKey(
                        name: "FK_BaseDatos_Inquilinos_BaseDatoOfInquilinoId",
                        column: x => x.BaseDatoOfInquilinoId,
                        principalTable: "Inquilinos",
                        principalColumn: "InquilinoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseDatos_Servidores_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidores",
                        principalColumn: "ServidorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDatos_BaseDatoOfInquilinoId",
                table: "BaseDatos",
                column: "BaseDatoOfInquilinoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseDatos_ServidorId",
                table: "BaseDatos",
                column: "ServidorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseDatos");

            migrationBuilder.DropTable(
                name: "Inquilinos");

            migrationBuilder.DropTable(
                name: "Servidores");
        }
    }
}
