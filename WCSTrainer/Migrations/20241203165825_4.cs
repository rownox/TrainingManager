using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationCategory_CategoryId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationCategory",
                table: "LocationCategory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e9835d9-28a4-4d4a-a032-bdd414350f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca33435-dcde-43cf-a9a7-7d8af1abb27f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db302c8f-4b33-483e-9367-32864bae109e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4af9743-4b8c-4a3b-a611-a58415ac09e3");

            migrationBuilder.RenameTable(
                name: "LocationCategory",
                newName: "LocationCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationCategories",
                table: "LocationCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "299b83e3-3a82-4200-a7a1-83f60af72013", null, "user", "USER" },
                    { "6c6439c8-84ad-4ca3-a2a7-39b90caedfeb", null, "owner", "OWNER" },
                    { "77e5bc33-4c30-4b8d-84d1-2c3ac56f01fe", null, "admin", "ADMIN" },
                    { "a2d52380-a009-4fa4-979a-989f794bea11", null, "guest", "GUEST" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationCategories_CategoryId",
                table: "Locations",
                column: "CategoryId",
                principalTable: "LocationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationCategories_CategoryId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationCategories",
                table: "LocationCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299b83e3-3a82-4200-a7a1-83f60af72013");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c6439c8-84ad-4ca3-a2a7-39b90caedfeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e5bc33-4c30-4b8d-84d1-2c3ac56f01fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d52380-a009-4fa4-979a-989f794bea11");

            migrationBuilder.RenameTable(
                name: "LocationCategories",
                newName: "LocationCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationCategory",
                table: "LocationCategory",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e9835d9-28a4-4d4a-a032-bdd414350f31", null, "guest", "GUEST" },
                    { "bca33435-dcde-43cf-a9a7-7d8af1abb27f", null, "owner", "OWNER" },
                    { "db302c8f-4b33-483e-9367-32864bae109e", null, "admin", "ADMIN" },
                    { "e4af9743-4b8c-4a3b-a611-a58415ac09e3", null, "user", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationCategory_CategoryId",
                table: "Locations",
                column: "CategoryId",
                principalTable: "LocationCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
