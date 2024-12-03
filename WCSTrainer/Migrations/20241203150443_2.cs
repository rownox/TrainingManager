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
                keyValue: "34a347db-234a-4d96-9c80-a35ea92cef16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4346e92-0975-4047-8f79-cb3168a1defe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7c9c3b2-9b98-42ac-a302-1f4654f245fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83e680b-d8b5-4075-bbed-6dc4d6ba7310");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LocationCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cc2e97d-2d7a-45a9-a0e1-e7cc57ae46a3", null, "admin", "ADMIN" },
                    { "6022a93d-6787-4e3c-b074-69bcfae8b4d6", null, "guest", "GUEST" },
                    { "abb18395-e7ed-4a2c-bf44-b8b054747211", null, "owner", "OWNER" },
                    { "d757eb15-2ed3-4309-b455-ee1939703723", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CategoryId",
                table: "Locations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationCategory_CategoryId",
                table: "Locations",
                column: "CategoryId",
                principalTable: "LocationCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationCategory_CategoryId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "LocationCategory");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CategoryId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc2e97d-2d7a-45a9-a0e1-e7cc57ae46a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6022a93d-6787-4e3c-b074-69bcfae8b4d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abb18395-e7ed-4a2c-bf44-b8b054747211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d757eb15-2ed3-4309-b455-ee1939703723");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34a347db-234a-4d96-9c80-a35ea92cef16", null, "owner", "OWNER" },
                    { "a4346e92-0975-4047-8f79-cb3168a1defe", null, "admin", "ADMIN" },
                    { "a7c9c3b2-9b98-42ac-a302-1f4654f245fc", null, "guest", "GUEST" },
                    { "e83e680b-d8b5-4075-bbed-6dc4d6ba7310", null, "user", "USER" }
                });
        }
    }
}
