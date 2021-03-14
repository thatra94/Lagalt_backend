using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagalt.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
