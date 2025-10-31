using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitumAPI.Migrations
{
    /// <inheritdoc />
    public partial class M03_FollowsTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowingUserId",
                table: "Follows",
                column: "FollowingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_FollowingUserId",
                table: "Follows",
                column: "FollowingUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_FollowingUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_UserId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowingUserId",
                table: "Follows");
        }
    }
}
