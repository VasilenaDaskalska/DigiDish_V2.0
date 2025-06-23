using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measure_users_LastUserModifiedID",
                table: "measure");

            migrationBuilder.DropForeignKey(
                name: "FK_measure_users_UserCreatorID",
                table: "measure");

            migrationBuilder.DropIndex(
                name: "IX_measure_LastUserModifiedID",
                table: "measure");

            migrationBuilder.DropIndex(
                name: "IX_measure_UserCreatorID",
                table: "measure");

            migrationBuilder.DropColumn(
                name: "LastPasswordModifiedDate",
                table: "MeasureLogs");

            migrationBuilder.DropColumn(
                name: "LastPasswordModifiedDate",
                table: "measure");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasureID = table.Column<long>(type: "bigint", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_product_measure_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "measure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    AuditLogID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasureID = table.Column<long>(type: "bigint", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductLogs_log_audit_logs_AuditLogID",
                        column: x => x.AuditLogID,
                        principalTable: "log_audit_logs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLogs_measure_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "measure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLogs_product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_MeasureID",
                table: "product",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_AuditLogID",
                table: "ProductLogs",
                column: "AuditLogID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_MeasureID",
                table: "ProductLogs",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ProductID",
                table: "ProductLogs",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLogs");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordModifiedDate",
                table: "MeasureLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordModifiedDate",
                table: "measure",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_measure_LastUserModifiedID",
                table: "measure",
                column: "LastUserModifiedID");

            migrationBuilder.CreateIndex(
                name: "IX_measure_UserCreatorID",
                table: "measure",
                column: "UserCreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_measure_users_LastUserModifiedID",
                table: "measure",
                column: "LastUserModifiedID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_measure_users_UserCreatorID",
                table: "measure",
                column: "UserCreatorID",
                principalTable: "users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
