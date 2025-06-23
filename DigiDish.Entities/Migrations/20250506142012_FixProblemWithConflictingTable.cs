using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class FixProblemWithConflictingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_LastUserModifiedID",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_users_UserCreatorID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_LastUserModifiedID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserCreatorID",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_LastUserModifiedID",
                table: "users",
                column: "LastUserModifiedID");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserCreatorID",
                table: "users",
                column: "UserCreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_LastUserModifiedID",
                table: "users",
                column: "LastUserModifiedID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_UserCreatorID",
                table: "users",
                column: "UserCreatorID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
