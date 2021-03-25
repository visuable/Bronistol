using Microsoft.EntityFrameworkCore.Migrations;

namespace Bronistol.Database.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntities_AssignedDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntities_SubmitDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_NameEntity_NameId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_PriorityEntity_PriorityId",
                "BookingEntities");

            migrationBuilder.DropPrimaryKey(
                "PK_PriorityEntity",
                "PriorityEntity");

            migrationBuilder.DropPrimaryKey(
                "PK_NameEntity",
                "NameEntity");

            migrationBuilder.DropPrimaryKey(
                "PK_DateEntities",
                "DateEntities");

            migrationBuilder.DropColumn(
                "DisplayDate",
                "DateEntities");

            migrationBuilder.DropColumn(
                "ShortDate",
                "DateEntities");

            migrationBuilder.RenameTable(
                "PriorityEntity",
                newName: "PriorityEntities");

            migrationBuilder.RenameTable(
                "NameEntity",
                newName: "NameEntities");

            migrationBuilder.RenameTable(
                "DateEntities",
                newName: "DateEntity");

            migrationBuilder.AddPrimaryKey(
                "PK_PriorityEntities",
                "PriorityEntities",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_NameEntities",
                "NameEntities",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_DateEntity",
                "DateEntity",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntity_AssignedDateId",
                "BookingEntities",
                "AssignedDateId",
                "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntity_SubmitDateId",
                "BookingEntities",
                "SubmitDateId",
                "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_NameEntities_NameId",
                "BookingEntities",
                "NameId",
                "NameEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_PriorityEntities_PriorityId",
                "BookingEntities",
                "PriorityId",
                "PriorityEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_AssignedDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_SubmitDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_NameEntities_NameId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_PriorityEntities_PriorityId",
                "BookingEntities");

            migrationBuilder.DropPrimaryKey(
                "PK_PriorityEntities",
                "PriorityEntities");

            migrationBuilder.DropPrimaryKey(
                "PK_NameEntities",
                "NameEntities");

            migrationBuilder.DropPrimaryKey(
                "PK_DateEntity",
                "DateEntity");

            migrationBuilder.RenameTable(
                "PriorityEntities",
                newName: "PriorityEntity");

            migrationBuilder.RenameTable(
                "NameEntities",
                newName: "NameEntity");

            migrationBuilder.RenameTable(
                "DateEntity",
                newName: "DateEntities");

            migrationBuilder.AddColumn<string>(
                "DisplayDate",
                "DateEntities",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ShortDate",
                "DateEntities",
                "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                "PK_PriorityEntity",
                "PriorityEntity",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_NameEntity",
                "NameEntity",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_DateEntities",
                "DateEntities",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntities_AssignedDateId",
                "BookingEntities",
                "AssignedDateId",
                "DateEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntities_SubmitDateId",
                "BookingEntities",
                "SubmitDateId",
                "DateEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_NameEntity_NameId",
                "BookingEntities",
                "NameId",
                "NameEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_PriorityEntity_PriorityId",
                "BookingEntities",
                "PriorityId",
                "PriorityEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}