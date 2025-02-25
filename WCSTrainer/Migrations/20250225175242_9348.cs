using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _9348 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Checklist",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Checklist",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
