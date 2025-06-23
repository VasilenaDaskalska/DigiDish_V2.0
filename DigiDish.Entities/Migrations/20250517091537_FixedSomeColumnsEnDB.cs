using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class FixedSomeColumnsEnDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_shopping_list_ShoppingListID",
                table: "ProductLogs");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RecipeLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "RecipeLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "ShoppingListID",
                table: "ProductLogs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeID",
                table: "ProductLogs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ShoppingListID",
                table: "product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeID",
                table: "product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product",
                column: "ShoppingListID",
                principalTable: "shopping_list",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_shopping_list_ShoppingListID",
                table: "ProductLogs",
                column: "ShoppingListID",
                principalTable: "shopping_list",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_shopping_list_ShoppingListID",
                table: "ProductLogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RecipeLogs");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "RecipeLogs");

            migrationBuilder.AlterColumn<long>(
                name: "ShoppingListID",
                table: "ProductLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RecipeID",
                table: "ProductLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ShoppingListID",
                table: "product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RecipeID",
                table: "product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_shopping_list_ShoppingListID",
                table: "product",
                column: "ShoppingListID",
                principalTable: "shopping_list",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs",
                column: "RecipeID",
                principalTable: "Recipes",
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
    }
}
