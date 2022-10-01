using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalkTutorial.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Regions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Regions",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "code");
        }
    }
}
