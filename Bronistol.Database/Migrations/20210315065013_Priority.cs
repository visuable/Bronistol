using Microsoft.EntityFrameworkCore.Migrations;

namespace Bronistol.Database.Migrations
{
    public partial class Priority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Points",
                table: "PriorityEntity",
                newName: "Priority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "PriorityEntity",
                newName: "Points");
        }
    }
}
