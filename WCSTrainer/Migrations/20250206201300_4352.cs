using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _4352 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "064960dc-bd15-423a-b185-eeacaa825a93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7984420a-47d6-4fe8-8c90-9fd5cbb3cc89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8644752-843d-470e-9aee-5b6e27efaa93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecd82cfb-ae1d-4edf-b03f-599e66599069");

            migrationBuilder.AlterColumn<int>(
                name: "Shift",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "182fbb19-c1a0-414c-b2d4-7f6255ca9682", null, "admin", "ADMIN" },
                    { "6a3385fc-d51d-4e57-a92d-1cc1d6601006", null, "owner", "OWNER" },
                    { "eb86e6e7-82ab-4ac4-b964-0ce9a6ac8606", null, "user", "USER" },
                    { "fe8af533-65d7-43c5-b2a1-576df8d96ca0", null, "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "182fbb19-c1a0-414c-b2d4-7f6255ca9682");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3385fc-d51d-4e57-a92d-1cc1d6601006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb86e6e7-82ab-4ac4-b964-0ce9a6ac8606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe8af533-65d7-43c5-b2a1-576df8d96ca0");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Shift",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "064960dc-bd15-423a-b185-eeacaa825a93", null, "guest", "GUEST" },
                    { "7984420a-47d6-4fe8-8c90-9fd5cbb3cc89", null, "owner", "OWNER" },
                    { "a8644752-843d-470e-9aee-5b6e27efaa93", null, "user", "USER" },
                    { "ecd82cfb-ae1d-4edf-b03f-599e66599069", null, "admin", "ADMIN" }
                });
        }
    }
}
