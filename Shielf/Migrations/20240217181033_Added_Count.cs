using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shielf.Migrations
{
    public partial class Added_Count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "ShielfBook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "ShielfBook");
        }
    }
}
