using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
    /// <inheritdoc />
    public partial class _9 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
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

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "Verifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                    { "53ee72dc-53b4-4934-ab19-61839130150c", null, "trainer", "TRAINER" },
                    { "756bc9a0-52cc-4f1d-83ec-712ca4a39f70", null, "trainee", "TRAINEE" },
                    { "d1279bb5-a328-4821-ae00-4d7401034460", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ee72dc-53b4-4934-ab19-61839130150c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "756bc9a0-52cc-4f1d-83ec-712ca4a39f70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1279bb5-a328-4821-ae00-4d7401034460");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Verifications");

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
                    { "5f27bf01-2a29-4145-b00e-e519c52774e3", null, "admin", "ADMIN" },
                    { "9ccdb163-c558-45d2-8ccf-63124fd737ce", null, "trainee", "TRAINEE" },
                    { "d49f2deb-f21c-49a3-a0cb-3f35488ed238", null, "trainer", "TRAINER" }
                });
        }
    }
}
