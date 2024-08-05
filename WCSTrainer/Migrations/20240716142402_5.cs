using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _5 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "4ca30a03-9265-40be-bc12-602684d4d000");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "5383132b-ad80-4b51-9f10-a3dbd9283fda");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "8678b72c-6502-434f-bca6-1843b4b10079");

         migrationBuilder.DropColumn(
             name: "SkillName",
             table: "TrainingOrders");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "0c69eb24-b1e2-401f-8dac-2259a653be06", null, "trainer", "TRAINER" },
                    { "3a256f1d-a537-4a69-88ee-ee64f744a120", null, "trainee", "TRAINEE" },
                    { "c925ed9a-0ce4-4b38-8b55-2270e8155be3", null, "admin", "ADMIN" }
             });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "0c69eb24-b1e2-401f-8dac-2259a653be06");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "3a256f1d-a537-4a69-88ee-ee64f744a120");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "c925ed9a-0ce4-4b38-8b55-2270e8155be3");

         migrationBuilder.AddColumn<string>(
             name: "SkillName",
             table: "TrainingOrders",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "4ca30a03-9265-40be-bc12-602684d4d000", null, "admin", "ADMIN" },
                    { "5383132b-ad80-4b51-9f10-a3dbd9283fda", null, "trainee", "TRAINEE" },
                    { "8678b72c-6502-434f-bca6-1843b4b10079", null, "trainer", "TRAINER" }
             });
      }
   }
}
