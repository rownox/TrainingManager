using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _294 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04273020-5231-4192-860c-54d5ee6e4da8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cccabc-f85a-48e1-93e3-0317de8b8c96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f82c90-750a-4615-b2e8-b2af60a8cdac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6475daf6-1c02-47c4-88d9-07d8771da02c");

            migrationBuilder.AddColumn<string>(
                name: "Checklist",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Checklist",
                table: "Skills");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04273020-5231-4192-860c-54d5ee6e4da8", null, "guest", "GUEST" },
                    { "37cccabc-f85a-48e1-93e3-0317de8b8c96", null, "admin", "ADMIN" },
                    { "56f82c90-750a-4615-b2e8-b2af60a8cdac", null, "user", "USER" },
                    { "6475daf6-1c02-47c4-88d9-07d8771da02c", null, "owner", "OWNER" }
                });
        }
    }
}
