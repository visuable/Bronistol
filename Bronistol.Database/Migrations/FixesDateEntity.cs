using Microsoft.EntityFrameworkCore.Migrations;

namespace Bronistol.Database.Migrations
{
    public partial class FixesDateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_AssignedDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_SubmitDateId",
                "BookingEntities");

            migrationBuilder.AlterColumn<int>(
                "SubmitDateId",
                "BookingEntities",
                "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                "AssignedDateId",
                "BookingEntities",
                "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntity_AssignedDateId",
                "BookingEntities",
                "AssignedDateId",
                "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_BookingEntities_DateEntity_SubmitDateId",
                "BookingEntities",
                "SubmitDateId",
                "DateEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_AssignedDateId",
                "BookingEntities");

            migrationBuilder.DropForeignKey(
                "FK_BookingEntities_DateEntity_SubmitDateId",
                "BookingEntities");

            migrationBuilder.AlterColumn<int>(
                "SubmitDateId",
                "BookingEntities",
                "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                "AssignedDateId",
                "BookingEntities",
                "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
        }
    }
}