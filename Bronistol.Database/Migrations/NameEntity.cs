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
                "NameId",
                "BookingEntities",
                "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                "NameEntity",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>("text", nullable: true),
                    FullName = table.Column<string>("text", nullable: true),
                    OrganizationName = table.Column<string>("text", nullable: true),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_NameEntity", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_NameId",
                "BookingEntities",
                "NameId");

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_NameEntity_NameId",
                "BookingEntities",
                "NameId",
                "NameEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_NameEntity_NameId",
                "BookingEntities");

            migrationBuilder.DropTable(
                "NameEntity");

            migrationBuilder.DropIndex(
                "IX_BookingEntities_NameId",
                "BookingEntities");

            migrationBuilder.DropColumn(
                "NameId",
                "BookingEntities");
        }
    }
}