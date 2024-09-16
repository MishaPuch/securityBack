using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScurityApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_SecurityObjects_SecurityObjectId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_SecurityObjectId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "SecurityObjectId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "WorkSheduleId",
                table: "Shifts");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_SecurityObjectId",
                table: "WorkSchedules",
                column: "SecurityObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_SecurityObjects_SecurityObjectId",
                table: "WorkSchedules",
                column: "SecurityObjectId",
                principalTable: "SecurityObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_SecurityObjects_SecurityObjectId",
                table: "WorkSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedules_SecurityObjectId",
                table: "WorkSchedules");

            migrationBuilder.AddColumn<int>(
                name: "SecurityObjectId",
                table: "Shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkSheduleId",
                table: "Shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_SecurityObjectId",
                table: "Shifts",
                column: "SecurityObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_SecurityObjects_SecurityObjectId",
                table: "Shifts",
                column: "SecurityObjectId",
                principalTable: "SecurityObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
