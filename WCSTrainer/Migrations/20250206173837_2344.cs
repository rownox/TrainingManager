using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _2344 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47be679a-6fae-4769-aebe-c3ff7ab5bfc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b3274f1-cecb-4ae0-b00d-80b9e6601235");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa8ec551-9303-47f6-819d-c6a1f534749e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdfc704e-89a7-487f-b374-bc8378dd2827");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e854ef5-b45c-45cd-b9e1-e712665bcb7d", null, "guest", "GUEST" },
                    { "21d008fc-d9f2-420e-950c-f60ffc6bc300", null, "admin", "ADMIN" },
                    { "3af2c903-a5ad-41cf-a894-645a18803fd1", null, "owner", "OWNER" },
                    { "6fa9ecc4-73c9-4afd-ac0f-253c472e0768", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e854ef5-b45c-45cd-b9e1-e712665bcb7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21d008fc-d9f2-420e-950c-f60ffc6bc300");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af2c903-a5ad-41cf-a894-645a18803fd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fa9ecc4-73c9-4afd-ac0f-253c472e0768");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47be679a-6fae-4769-aebe-c3ff7ab5bfc8", null, "owner", "OWNER" },
                    { "7b3274f1-cecb-4ae0-b00d-80b9e6601235", null, "admin", "ADMIN" },
                    { "aa8ec551-9303-47f6-819d-c6a1f534749e", null, "user", "USER" },
                    { "fdfc704e-89a7-487f-b374-bc8378dd2827", null, "guest", "GUEST" }
                });
        }
    }
}
