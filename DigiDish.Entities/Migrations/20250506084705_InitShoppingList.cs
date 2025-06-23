using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitShoppingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShoppingListID",
                table: "ProductLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ShoppingListID",
                table: "product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "shopping_list",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_list", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ShoppingListID",
                table: "ProductLogs",
                column: "ShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_product_ShoppingListID",
                table: "product",
                column: "ShoppingListID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product",
                column: "ShoppingListID",
                principalTable: "shopping_list",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_shopping_list_ShoppingListID",
                table: "ProductLogs",
                column: "ShoppingListID",
                principalTable: "shopping_list",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_shopping_list_ShoppingListID",
                table: "ProductLogs");

            migrationBuilder.DropTable(
                name: "shopping_list");

            migrationBuilder.DropIndex(
                name: "IX_ProductLogs_ShoppingListID",
                table: "ProductLogs");

            migrationBuilder.DropIndex(
                name: "IX_product_ShoppingListID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ShoppingListID",
                table: "ProductLogs");

            migrationBuilder.DropColumn(
                name: "ShoppingListID",
                table: "product");
        }
    }
}
