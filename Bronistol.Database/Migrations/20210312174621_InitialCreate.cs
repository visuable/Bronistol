using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bronistol.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DateEntities",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    ShortDate = table.Column<string>("text", nullable: true),
                    DisplayDate = table.Column<string>("text", nullable: true),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_DateEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "NoteEntities",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>("text", nullable: true),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_NoteEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "PriorityEntity",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Points = table.Column<int>("integer", nullable: false),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PriorityEntity", x => x.Id); });

            migrationBuilder.CreateTable(
                "ReasonEntities",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>("text", nullable: true),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ReasonEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "BookingEntities",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReasonId = table.Column<int>("integer", nullable: true),
                    NoteId = table.Column<int>("integer", nullable: true),
                    PriorityId = table.Column<int>("integer", nullable: true),
                    SubmitDateId = table.Column<int>("integer", nullable: true),
                    AssignedDateId = table.Column<int>("integer", nullable: true),
                    Created = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntities", x => x.Id);
                    table.ForeignKey(
                        "FK_BookingEntities_DateEntities_AssignedDateId",
                        x => x.AssignedDateId,
                        "DateEntities",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_BookingEntities_DateEntities_SubmitDateId",
                        x => x.SubmitDateId,
                        "DateEntities",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_BookingEntities_NoteEntities_NoteId",
                        x => x.NoteId,
                        "NoteEntities",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_BookingEntities_PriorityEntity_PriorityId",
                        x => x.PriorityId,
                        "PriorityEntity",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_BookingEntities_ReasonEntities_ReasonId",
                        x => x.ReasonId,
                        "ReasonEntities",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_AssignedDateId",
                "BookingEntities",
                "AssignedDateId");

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_NoteId",
                "BookingEntities",
                "NoteId");

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_PriorityId",
                "BookingEntities",
                "PriorityId");

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_ReasonId",
                "BookingEntities",
                "ReasonId");

            migrationBuilder.CreateIndex(
                "IX_BookingEntities_SubmitDateId",
                "BookingEntities",
                "SubmitDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BookingEntities");

            migrationBuilder.DropTable(
                "DateEntities");

            migrationBuilder.DropTable(
                "NoteEntities");

            migrationBuilder.DropTable(
                "PriorityEntity");

            migrationBuilder.DropTable(
                "ReasonEntities");
        }
    }
}