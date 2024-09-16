using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScurityApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addcapasity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeCopasity",
                table: "WorkSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCopasity",
                table: "WorkSchedules");
        }
    }
}
