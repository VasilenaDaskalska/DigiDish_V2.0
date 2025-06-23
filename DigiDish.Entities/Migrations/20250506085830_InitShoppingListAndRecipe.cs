using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitShoppingListAndRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RecipeID",
                table: "ProductLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RecipeID",
                table: "product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListlogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListID = table.Column<long>(type: "bigint", nullable: false),
                    AuditLogID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListlogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingListlogs_log_audit_logs_AuditLogID",
                        column: x => x.AuditLogID,
                        principalTable: "log_audit_logs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListlogs_shopping_list_ShoppingListID",
                        column: x => x.ShoppingListID,
                        principalTable: "shopping_list",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeLogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<long>(type: "bigint", nullable: false),
                    AuditLogID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeLogs_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeLogs_log_audit_logs_AuditLogID",
                        column: x => x.AuditLogID,
                        principalTable: "log_audit_logs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_RecipeID",
                table: "ProductLogs",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_product_RecipeID",
                table: "product",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLogs_AuditLogID",
                table: "RecipeLogs",
                column: "AuditLogID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLogs_RecipeID",
                table: "RecipeLogs",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListlogs_AuditLogID",
                table: "ShoppingListlogs",
                column: "AuditLogID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListlogs_ShoppingListID",
                table: "ShoppingListlogs",
                column: "ShoppingListID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Recipes_RecipeID",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_Recipes_RecipeID",
                table: "ProductLogs");

            migrationBuilder.DropTable(
                name: "RecipeLogs");

            migrationBuilder.DropTable(
                name: "ShoppingListlogs");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductLogs_RecipeID",
                table: "ProductLogs");

            migrationBuilder.DropIndex(
                name: "IX_product_RecipeID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "ProductLogs");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "product");
        }
    }
}
