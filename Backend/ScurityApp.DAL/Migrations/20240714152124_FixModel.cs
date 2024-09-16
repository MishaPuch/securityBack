using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScurityApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
