using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
    /// <inheritdoc />
    public partial class _7 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a54bb44f-1c60-46e6-9b1e-9e926a92791e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba6baa2a-63c3-4f6e-862c-688323964391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f64c5de4-3afa-4f7e-8a0b-81905c011766");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bc52ed9-ddf4-4e77-b73e-4913e1adaf48", null, "admin", "ADMIN" },
                    { "4927e1fc-877c-40dc-bff2-a55f5aa18477", null, "trainee", "TRAINEE" },
                    { "b9364d79-3371-45e5-b331-5e70be66faa7", null, "trainer", "TRAINER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bc52ed9-ddf4-4e77-b73e-4913e1adaf48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4927e1fc-877c-40dc-bff2-a55f5aa18477");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9364d79-3371-45e5-b331-5e70be66faa7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a54bb44f-1c60-46e6-9b1e-9e926a92791e", null, "trainer", "TRAINER" },
                    { "ba6baa2a-63c3-4f6e-862c-688323964391", null, "admin", "ADMIN" },
                    { "f64c5de4-3afa-4f7e-8a0b-81905c011766", null, "trainee", "TRAINEE" }
                });
        }
    }
}
