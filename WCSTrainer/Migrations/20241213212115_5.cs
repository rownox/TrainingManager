using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonCategories_Employees_EmployeeId",
                table: "LessonCategories");

            migrationBuilder.DropIndex(
                name: "IX_LessonCategories_EmployeeId",
                table: "LessonCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66e42d2d-ccb8-4867-bab1-b8548e61ca92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bd83fad-a5fa-4dc2-ad93-8d18408910a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f342ad4-75c9-4c46-a813-294fe109b0e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0bb41d0-73b5-4cd9-bcbf-25cdba37987e");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LessonCategories");

            migrationBuilder.CreateTable(
                name: "EmployeeLessonCategory",
                columns: table => new
                {
                    TrainerDepartmentsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLessonCategory", x => new { x.TrainerDepartmentsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_EmployeeLessonCategory_Employees_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLessonCategory_LessonCategories_TrainerDepartmentsId",
                        column: x => x.TrainerDepartmentsId,
                        principalTable: "LessonCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2617a011-b3fc-40d3-879a-cf53f12ddc34", null, "owner", "OWNER" },
                    { "64b4121d-9844-4ed5-9595-72dcbf146183", null, "guest", "GUEST" },
                    { "75a9d20e-e4ed-4789-b7bb-7a5a267760fb", null, "admin", "ADMIN" },
                    { "f647c8a9-78e3-4295-8dda-6f118ea9f8e5", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLessonCategory_TrainersId",
                table: "EmployeeLessonCategory",
                column: "TrainersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLessonCategory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2617a011-b3fc-40d3-879a-cf53f12ddc34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b4121d-9844-4ed5-9595-72dcbf146183");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a9d20e-e4ed-4789-b7bb-7a5a267760fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f647c8a9-78e3-4295-8dda-6f118ea9f8e5");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "LessonCategories",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66e42d2d-ccb8-4867-bab1-b8548e61ca92", null, "admin", "ADMIN" },
                    { "8bd83fad-a5fa-4dc2-ad93-8d18408910a4", null, "owner", "OWNER" },
                    { "9f342ad4-75c9-4c46-a813-294fe109b0e2", null, "guest", "GUEST" },
                    { "d0bb41d0-73b5-4cd9-bcbf-25cdba37987e", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonCategories_EmployeeId",
                table: "LessonCategories",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonCategories_Employees_EmployeeId",
                table: "LessonCategories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
