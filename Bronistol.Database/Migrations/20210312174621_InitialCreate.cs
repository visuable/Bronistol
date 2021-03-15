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
                name: "DateEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ShortDate = table.Column<string>(type: "text", nullable: true),
                    DisplayDate = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriorityEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReasonId = table.Column<int>(type: "integer", nullable: true),
                    NoteId = table.Column<int>(type: "integer", nullable: true),
                    PriorityId = table.Column<int>(type: "integer", nullable: true),
                    SubmitDateId = table.Column<int>(type: "integer", nullable: true),
                    AssignedDateId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingEntities_DateEntities_AssignedDateId",
                        column: x => x.AssignedDateId,
                        principalTable: "DateEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingEntities_DateEntities_SubmitDateId",
                        column: x => x.SubmitDateId,
                        principalTable: "DateEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingEntities_NoteEntities_NoteId",
                        column: x => x.NoteId,
                        principalTable: "NoteEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingEntities_PriorityEntity_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "PriorityEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingEntities_ReasonEntities_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "ReasonEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_AssignedDateId",
                table: "BookingEntities",
                column: "AssignedDateId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_NoteId",
                table: "BookingEntities",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_PriorityId",
                table: "BookingEntities",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_ReasonId",
                table: "BookingEntities",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_SubmitDateId",
                table: "BookingEntities",
                column: "SubmitDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEntities");

            migrationBuilder.DropTable(
                name: "DateEntities");

            migrationBuilder.DropTable(
                name: "NoteEntities");

            migrationBuilder.DropTable(
                name: "PriorityEntity");

            migrationBuilder.DropTable(
                name: "ReasonEntities");
        }
    }
}
