using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
    /// <inheritdoc />
    public partial class _8 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
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

            migrationBuilder.DropColumn(
                name: "CompleteNotes",
                table: "Verifications");

            migrationBuilder.AddColumn<string>(
                name: "ClosingNotes",
                table: "TrainingOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f27bf01-2a29-4145-b00e-e519c52774e3", null, "admin", "ADMIN" },
                    { "9ccdb163-c558-45d2-8ccf-63124fd737ce", null, "trainee", "TRAINEE" },
                    { "d49f2deb-f21c-49a3-a0cb-3f35488ed238", null, "trainer", "TRAINER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f27bf01-2a29-4145-b00e-e519c52774e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ccdb163-c558-45d2-8ccf-63124fd737ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49f2deb-f21c-49a3-a0cb-3f35488ed238");

            migrationBuilder.DropColumn(
                name: "ClosingNotes",
                table: "TrainingOrders");

            migrationBuilder.AddColumn<string>(
                name: "CompleteNotes",
                table: "Verifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
