using Microsoft.EntityFrameworkCore.Migrations;

namespace PK_zaliczenie_web_1.Migrations
{
    public partial class AddPhotopathColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "units",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "units");
        }
    }
}
