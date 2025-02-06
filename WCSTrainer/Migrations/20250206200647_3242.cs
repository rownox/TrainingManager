using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _3242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Status",
                table: "Employees");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
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
    }
}
