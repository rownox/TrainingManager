using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _9343 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "072b2733-ac05-4834-8374-d8bd41912d9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ea73bf9-8719-48c8-86fd-81659746d1a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba981b6c-c71d-4060-852a-9fb9d46a16df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1c23d7c-2e56-45c0-8ecb-8b9379326ec9");

            migrationBuilder.AlterColumn<string>(
                name: "Shift",
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
                    { "08b0a030-be77-48a3-8891-d7dea411cffa", null, "admin", "ADMIN" },
                    { "6542409f-2dc5-4c78-8517-06776d7555a2", null, "owner", "OWNER" },
                    { "932ca792-0a69-448f-8487-f75b8eb7cb16", null, "user", "USER" },
                    { "d6ba6a74-199a-46eb-aca4-9463e11f97c0", null, "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08b0a030-be77-48a3-8891-d7dea411cffa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6542409f-2dc5-4c78-8517-06776d7555a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932ca792-0a69-448f-8487-f75b8eb7cb16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6ba6a74-199a-46eb-aca4-9463e11f97c0");

            migrationBuilder.AlterColumn<int>(
                name: "Shift",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "072b2733-ac05-4834-8374-d8bd41912d9d", null, "admin", "ADMIN" },
                    { "1ea73bf9-8719-48c8-86fd-81659746d1a6", null, "user", "USER" },
                    { "ba981b6c-c71d-4060-852a-9fb9d46a16df", null, "guest", "GUEST" },
                    { "c1c23d7c-2e56-45c0-8ecb-8b9379326ec9", null, "owner", "OWNER" }
                });
        }
    }
}
