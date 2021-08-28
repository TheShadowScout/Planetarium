using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetariumData.Migrations
{
    public partial class dodanepolestarsystemid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StarSystemId",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarSystemId",
                table: "Planets");
        }
    }
}
