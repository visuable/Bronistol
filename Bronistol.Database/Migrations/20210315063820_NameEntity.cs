using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bronistol.Database.Migrations
{
    public partial class NameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "BookingEntities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NameEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    OrganizationName = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_NameId",
                table: "BookingEntities",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_NameEntity_NameId",
                table: "BookingEntities",
                column: "NameId",
                principalTable: "NameEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_NameEntity_NameId",
                table: "BookingEntities");

            migrationBuilder.DropTable(
                name: "NameEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookingEntities_NameId",
                table: "BookingEntities");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "BookingEntities");
        }
    }
}
