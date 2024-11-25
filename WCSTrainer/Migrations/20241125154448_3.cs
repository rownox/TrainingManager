using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06988f7e-8e55-405c-b14d-93fcbcfca878", null, "admin", "ADMIN" },
                    { "6c46252c-a235-4249-95e5-4b06c5c11727", null, "user", "USER" },
                    { "bc60c116-8b65-459f-8eaf-0d4ba2112c6d", null, "owner", "OWNER" },
                    { "f5eb4779-0694-4412-a52c-f69a84d30999", null, "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06988f7e-8e55-405c-b14d-93fcbcfca878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c46252c-a235-4249-95e5-4b06c5c11727");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc60c116-8b65-459f-8eaf-0d4ba2112c6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5eb4779-0694-4412-a52c-f69a84d30999");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Descriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
