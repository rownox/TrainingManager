using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "564c4c58-b569-47ba-bc2c-7151ca0bc463");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b4ca516-7d0d-470f-9abc-343f22f38bbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86cb44a4-1f63-455e-aaf1-510be41f43fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b745a3f3-91e1-43b9-8d13-a44988ac777f");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "564c4c58-b569-47ba-bc2c-7151ca0bc463", null, "owner", "OWNER" },
                    { "6b4ca516-7d0d-470f-9abc-343f22f38bbd", null, "guest", "GUEST" },
                    { "86cb44a4-1f63-455e-aaf1-510be41f43fa", null, "admin", "ADMIN" },
                    { "b745a3f3-91e1-43b9-8d13-a44988ac777f", null, "user", "USER" }
                });
        }
    }
}
