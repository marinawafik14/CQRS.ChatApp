using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class alterTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_UsersId",
                table: "BlockedUsers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "BlockedUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockedUsers_UsersId",
                table: "BlockedUsers",
                newName: "IX_BlockedUsers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_UserId",
                table: "BlockedUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_UserId",
                table: "BlockedUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BlockedUsers",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockedUsers_UserId",
                table: "BlockedUsers",
                newName: "IX_BlockedUsers_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_UsersId",
                table: "BlockedUsers",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
