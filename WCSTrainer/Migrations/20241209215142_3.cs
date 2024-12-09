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
                keyValue: "aa42f9df-cef1-40b1-b670-ad53a8915e2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b5a8a4-a080-4a82-9b32-9fb16fb1690a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66b4c96-c925-44c1-b00b-e3c80c957281");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edc22682-7157-488b-8bf8-87c00d42b584");

            migrationBuilder.AlterColumn<string>(
                name: "ClosingNotes",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ClosingNotes",
                table: "TrainingOrders",
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
                    { "aa42f9df-cef1-40b1-b670-ad53a8915e2e", null, "admin", "ADMIN" },
                    { "d1b5a8a4-a080-4a82-9b32-9fb16fb1690a", null, "user", "USER" },
                    { "e66b4c96-c925-44c1-b00b-e3c80c957281", null, "guest", "GUEST" },
                    { "edc22682-7157-488b-8bf8-87c00d42b584", null, "owner", "OWNER" }
                });
        }
    }
}
