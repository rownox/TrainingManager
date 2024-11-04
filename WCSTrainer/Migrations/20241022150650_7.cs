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
             keyValue: "553110f3-dac1-4bbe-9815-6fdb0358042a");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "999de91f-aa6a-45ca-8e7c-939e0ec8c320");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "eced5181-4e27-4989-8378-f84a8da0492c");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "fcfa4778-8c8c-4a16-800b-317ef7d5816d");

         migrationBuilder.AddColumn<int>(
             name: "SkillId",
             table: "TrainingOrders",
             type: "int",
             nullable: true);

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "26fb1bef-f0de-41a1-b2aa-557c695da631", null, "admin", "ADMIN" },
                    { "4770d226-8abb-4012-8556-eeef905e596c", null, "guest", "GUEST" },
                    { "4d68d7a0-ecdc-45ba-a931-1f9c66112e5e", null, "owner", "OWNER" },
                    { "de1fa438-96b0-4bae-9c82-04d18639d22e", null, "user", "USER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_TrainingOrders_SkillId",
             table: "TrainingOrders",
             column: "SkillId");

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Skills_SkillId",
             table: "TrainingOrders",
             column: "SkillId",
             principalTable: "Skills",
             principalColumn: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Skills_SkillId",
             table: "TrainingOrders");

         migrationBuilder.DropIndex(
             name: "IX_TrainingOrders_SkillId",
             table: "TrainingOrders");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "26fb1bef-f0de-41a1-b2aa-557c695da631");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "4770d226-8abb-4012-8556-eeef905e596c");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "4d68d7a0-ecdc-45ba-a931-1f9c66112e5e");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "de1fa438-96b0-4bae-9c82-04d18639d22e");

         migrationBuilder.DropColumn(
             name: "SkillId",
             table: "TrainingOrders");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "553110f3-dac1-4bbe-9815-6fdb0358042a", null, "admin", "ADMIN" },
                    { "999de91f-aa6a-45ca-8e7c-939e0ec8c320", null, "guest", "GUEST" },
                    { "eced5181-4e27-4989-8378-f84a8da0492c", null, "user", "USER" },
                    { "fcfa4778-8c8c-4a16-800b-317ef7d5816d", null, "owner", "OWNER" }
             });
      }
   }
}
