using Microsoft.EntityFrameworkCore.Migrations;

namespace TecSoftware.Infrastructure.Migrations
{
    public partial class AgregandoConnInquilino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatabaseConnectionString",
                table: "Inquilinos",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatabaseConnectionString",
                table: "Inquilinos");
        }
    }
}
