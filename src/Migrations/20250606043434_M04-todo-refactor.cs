using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitumAPI.Migrations
{
    /// <inheritdoc />
    public partial class M04todorefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Todos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Todos",
                newName: "CompletedAt");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Todos",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CompletedAt",
                table: "Todos",
                newName: "EndDate");
        }
    }
}
