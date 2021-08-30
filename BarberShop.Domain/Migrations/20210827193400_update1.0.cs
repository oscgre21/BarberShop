using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop.Domain.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades");

            migrationBuilder.RenameTable(
                name: "Ciudades",
                newName: "Demo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Demo",
                table: "Demo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Demo",
                table: "Demo");

            migrationBuilder.RenameTable(
                name: "Demo",
                newName: "Ciudades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades",
                column: "Id");
        }
    }
}
