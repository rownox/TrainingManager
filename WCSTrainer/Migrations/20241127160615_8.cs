using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46de173c-378f-4f57-9456-18941690dc9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98fad56d-8806-4d97-bf6d-abe02ca36cc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1479489-3a6c-498b-8b7b-0d6854c2ff82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcbad8c5-ccea-40ae-b738-5c4f8b82e4b5");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eaf5a21-9307-4fc9-911d-f3216d8e1dbc", null, "user", "USER" },
                    { "4d0e87cf-c434-43d3-a635-644f920ca6bc", null, "guest", "GUEST" },
                    { "5df5929e-990d-4432-9257-08a9951356b2", null, "owner", "OWNER" },
                    { "9693aa2c-72ee-4ace-9d48-5d1fdf6c9867", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eaf5a21-9307-4fc9-911d-f3216d8e1dbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d0e87cf-c434-43d3-a635-644f920ca6bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df5929e-990d-4432-9257-08a9951356b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9693aa2c-72ee-4ace-9d48-5d1fdf6c9867");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Descriptions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46de173c-378f-4f57-9456-18941690dc9a", null, "guest", "GUEST" },
                    { "98fad56d-8806-4d97-bf6d-abe02ca36cc5", null, "owner", "OWNER" },
                    { "b1479489-3a6c-498b-8b7b-0d6854c2ff82", null, "admin", "ADMIN" },
                    { "dcbad8c5-ccea-40ae-b738-5c4f8b82e4b5", null, "user", "USER" }
                });
        }
    }
}
