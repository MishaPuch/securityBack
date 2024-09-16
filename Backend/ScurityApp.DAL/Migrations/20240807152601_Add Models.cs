using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScurityApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_Employees_EmployeeId",
                table: "WorkSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedules_EmployeeId",
                table: "WorkSchedules");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "WorkSchedules");

            migrationBuilder.RenameColumn(
                name: "WorkHours",
                table: "WorkSchedules",
                newName: "SecurityObjectId");

            migrationBuilder.CreateTable(
                name: "SecurityObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectAddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityObjects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WorkSheduleId = table.Column<int>(type: "int", nullable: false),
                    SecurityObjectId = table.Column<int>(type: "int", nullable: false),
                    ShiftHours = table.Column<int>(type: "int", nullable: false),
                    WorkScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_SecurityObjects_SecurityObjectId",
                        column: x => x.SecurityObjectId,
                        principalTable: "SecurityObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_WorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "WorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityObjects_DepartmentId",
                table: "SecurityObjects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeeId",
                table: "Shifts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_SecurityObjectId",
                table: "Shifts",
                column: "SecurityObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkScheduleId",
                table: "Shifts",
                column: "WorkScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "SecurityObjects");

            migrationBuilder.RenameColumn(
                name: "SecurityObjectId",
                table: "WorkSchedules",
                newName: "WorkHours");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "WorkSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_EmployeeId",
                table: "WorkSchedules",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_Employees_EmployeeId",
                table: "WorkSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
