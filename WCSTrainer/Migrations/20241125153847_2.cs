using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "273b8e15-8e4f-4834-a4fa-95c2127ffc64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea5e590-f1cf-4ae6-bb79-387ad205ee79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "360eb5e7-8621-4bf9-97b2-5cab85f22d4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb08da74-74d7-451a-8c24-6a578d9f5e57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ff2a0a9-614d-4684-a465-d29c47bbb91d", null, "admin", "ADMIN" },
                    { "5bc36e81-a28d-4c32-b122-69ff6a198712", null, "user", "USER" },
                    { "a42eb97a-d4ce-464f-a3a5-e68260a94670", null, "owner", "OWNER" },
                    { "db289f93-20f6-4c5d-b0c4-a54bc2d379f1", null, "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff2a0a9-614d-4684-a465-d29c47bbb91d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc36e81-a28d-4c32-b122-69ff6a198712");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a42eb97a-d4ce-464f-a3a5-e68260a94670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db289f93-20f6-4c5d-b0c4-a54bc2d379f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "273b8e15-8e4f-4834-a4fa-95c2127ffc64", null, "user", "USER" },
                    { "2ea5e590-f1cf-4ae6-bb79-387ad205ee79", null, "admin", "ADMIN" },
                    { "360eb5e7-8621-4bf9-97b2-5cab85f22d4a", null, "guest", "GUEST" },
                    { "fb08da74-74d7-451a-8c24-6a578d9f5e57", null, "owner", "OWNER" }
                });
        }
    }
}
