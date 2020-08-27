using Microsoft.EntityFrameworkCore.Migrations;

namespace GameSite.Migrations
{
    public partial class GameSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
