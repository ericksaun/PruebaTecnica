using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.EFCore.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor",
                table: "movimientos");

            migrationBuilder.AddColumn<double>(
                name: "mo_valor",
                table: "movimientos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mo_valor",
                table: "movimientos");

            migrationBuilder.AddColumn<int>(
                name: "valor",
                table: "movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
