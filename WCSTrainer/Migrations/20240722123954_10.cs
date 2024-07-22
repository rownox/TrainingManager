using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications");

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

            migrationBuilder.AlterColumn<string>(
                name: "VerifierId",
                table: "Verifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09e92e70-3ce3-4dae-aa54-2ce355b8b3ad", null, "trainer", "TRAINER" },
                    { "5b9b2202-ff17-4870-9842-d61a32a3db58", null, "admin", "ADMIN" },
                    { "6db0fd16-de04-46a0-8d02-8c5d6d7f8c51", null, "trainee", "TRAINEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_AspNetUsers_VerifierId",
                table: "Verifications",
                column: "VerifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_AspNetUsers_VerifierId",
                table: "Verifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e92e70-3ce3-4dae-aa54-2ce355b8b3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9b2202-ff17-4870-9842-d61a32a3db58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6db0fd16-de04-46a0-8d02-8c5d6d7f8c51");

            migrationBuilder.AlterColumn<int>(
                name: "VerifierId",
                table: "Verifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Employees_VerifierId",
                table: "Verifications",
                column: "VerifierId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
