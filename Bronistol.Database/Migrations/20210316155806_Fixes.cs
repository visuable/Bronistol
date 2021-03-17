using Microsoft.EntityFrameworkCore.Migrations;

namespace Bronistol.Database.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntities_AssignedDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntities_SubmitDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_NameEntity_NameId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_PriorityEntity_PriorityId",
                table: "BookingEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityEntity",
                table: "PriorityEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NameEntity",
                table: "NameEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateEntities",
                table: "DateEntities");

            migrationBuilder.DropColumn(
                name: "DisplayDate",
                table: "DateEntities");

            migrationBuilder.DropColumn(
                name: "ShortDate",
                table: "DateEntities");

            migrationBuilder.RenameTable(
                name: "PriorityEntity",
                newName: "PriorityEntities");

            migrationBuilder.RenameTable(
                name: "NameEntity",
                newName: "NameEntities");

            migrationBuilder.RenameTable(
                name: "DateEntities",
                newName: "DateEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityEntities",
                table: "PriorityEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NameEntities",
                table: "NameEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateEntity",
                table: "DateEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntity_AssignedDateId",
                table: "BookingEntities",
                column: "AssignedDateId",
                principalTable: "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntity_SubmitDateId",
                table: "BookingEntities",
                column: "SubmitDateId",
                principalTable: "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_NameEntities_NameId",
                table: "BookingEntities",
                column: "NameId",
                principalTable: "NameEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_PriorityEntities_PriorityId",
                table: "BookingEntities",
                column: "PriorityId",
                principalTable: "PriorityEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_AssignedDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_SubmitDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_NameEntities_NameId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_PriorityEntities_PriorityId",
                table: "BookingEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityEntities",
                table: "PriorityEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NameEntities",
                table: "NameEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateEntity",
                table: "DateEntity");

            migrationBuilder.RenameTable(
                name: "PriorityEntities",
                newName: "PriorityEntity");

            migrationBuilder.RenameTable(
                name: "NameEntities",
                newName: "NameEntity");

            migrationBuilder.RenameTable(
                name: "DateEntity",
                newName: "DateEntities");

            migrationBuilder.AddColumn<string>(
                name: "DisplayDate",
                table: "DateEntities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDate",
                table: "DateEntities",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityEntity",
                table: "PriorityEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NameEntity",
                table: "NameEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateEntities",
                table: "DateEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntities_AssignedDateId",
                table: "BookingEntities",
                column: "AssignedDateId",
                principalTable: "DateEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntities_SubmitDateId",
                table: "BookingEntities",
                column: "SubmitDateId",
                principalTable: "DateEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_NameEntity_NameId",
                table: "BookingEntities",
                column: "NameId",
                principalTable: "NameEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_PriorityEntity_PriorityId",
                table: "BookingEntities",
                column: "PriorityId",
                principalTable: "PriorityEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
