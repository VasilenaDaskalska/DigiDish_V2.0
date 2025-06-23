using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitMeasureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "measure",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPasswordModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measure", x => x.ID);
                    table.ForeignKey(
                        name: "FK_measure_users_LastUserModifiedID",
                        column: x => x.LastUserModifiedID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_measure_users_UserCreatorID",
                        column: x => x.UserCreatorID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasureLogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureID = table.Column<long>(type: "bigint", nullable: false),
                    AuditLogID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatorID = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserModifiedID = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPasswordModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeasureLogs_log_audit_logs_AuditLogID",
                        column: x => x.AuditLogID,
                        principalTable: "log_audit_logs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasureLogs_measure_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "measure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_measure_LastUserModifiedID",
                table: "measure",
                column: "LastUserModifiedID");

            migrationBuilder.CreateIndex(
                name: "IX_measure_UserCreatorID",
                table: "measure",
                column: "UserCreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureLogs_AuditLogID",
                table: "MeasureLogs",
                column: "AuditLogID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureLogs_MeasureID",
                table: "MeasureLogs",
                column: "MeasureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasureLogs");

            migrationBuilder.DropTable(
                name: "measure");
        }
    }
}
