using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop.Domain.Migrations
{
    public partial class Barbersop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "authkey",
                table: "Indentity",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authkey",
                table: "Indentity");
        }
    }
}
