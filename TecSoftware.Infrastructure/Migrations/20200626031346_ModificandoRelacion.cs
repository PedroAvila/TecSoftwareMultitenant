using Microsoft.EntityFrameworkCore.Migrations;

namespace TecSoftware.Infrastructure.Migrations
{
    public partial class ModificandoRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquilinos_BaseDatos_InquilinoId",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "InquilinoId",
                table: "BaseDatos");

            migrationBuilder.AddColumn<int>(
                name: "BaseDatoOfInquilinoId",
                table: "BaseDatos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BaseDatos_BaseDatoOfInquilinoId",
                table: "BaseDatos",
                column: "BaseDatoOfInquilinoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDatos_Inquilinos_BaseDatoOfInquilinoId",
                table: "BaseDatos",
                column: "BaseDatoOfInquilinoId",
                principalTable: "Inquilinos",
                principalColumn: "InquilinoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDatos_Inquilinos_BaseDatoOfInquilinoId",
                table: "BaseDatos");

            migrationBuilder.DropIndex(
                name: "IX_BaseDatos_BaseDatoOfInquilinoId",
                table: "BaseDatos");

            migrationBuilder.DropColumn(
                name: "BaseDatoOfInquilinoId",
                table: "BaseDatos");

            migrationBuilder.AddColumn<int>(
                name: "InquilinoId",
                table: "BaseDatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquilinos_BaseDatos_InquilinoId",
                table: "Inquilinos",
                column: "InquilinoId",
                principalTable: "BaseDatos",
                principalColumn: "BaseDatoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
