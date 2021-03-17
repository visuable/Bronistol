using Microsoft.EntityFrameworkCore.Migrations;

namespace Bronistol.Database.Migrations
{
    public partial class FixesDateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_AssignedDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_SubmitDateId",
                table: "BookingEntities");

            migrationBuilder.AlterColumn<int>(
                name: "SubmitDateId",
                table: "BookingEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedDateId",
                table: "BookingEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntity_AssignedDateId",
                table: "BookingEntities",
                column: "AssignedDateId",
                principalTable: "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_DateEntity_SubmitDateId",
                table: "BookingEntities",
                column: "SubmitDateId",
                principalTable: "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_AssignedDateId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_DateEntity_SubmitDateId",
                table: "BookingEntities");

            migrationBuilder.AlterColumn<int>(
                name: "SubmitDateId",
                table: "BookingEntities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedDateId",
                table: "BookingEntities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
        }
    }
}
