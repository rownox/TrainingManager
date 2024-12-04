using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _21 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "26d0cff0-c661-46db-8296-a2a40865bfba");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "42ff162c-2621-44fe-b53f-2c6cdad8e3d9");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "a28842fe-fbe8-4004-a0e7-41826f8f608e");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "cda84c47-3e55-4fa4-80fb-3d37e76cdfb8");

         migrationBuilder.DropColumn(
             name: "Medium",
             table: "TrainingOrders");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "038e57c2-f485-48e8-bce2-dc58e53ac0d5", null, "user", "USER" },
                    { "73abf533-c3df-4348-8b74-48501c9a6f36", null, "admin", "ADMIN" },
                    { "8f479af0-3f30-49ac-877c-d59a30bc2e29", null, "guest", "GUEST" },
                    { "a197d4e5-1758-417f-b9f0-8fa4198b36c5", null, "owner", "OWNER" }
             });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "038e57c2-f485-48e8-bce2-dc58e53ac0d5");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "73abf533-c3df-4348-8b74-48501c9a6f36");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "8f479af0-3f30-49ac-877c-d59a30bc2e29");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "a197d4e5-1758-417f-b9f0-8fa4198b36c5");

         migrationBuilder.AddColumn<string>(
             name: "Medium",
             table: "TrainingOrders",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "26d0cff0-c661-46db-8296-a2a40865bfba", null, "owner", "OWNER" },
                    { "42ff162c-2621-44fe-b53f-2c6cdad8e3d9", null, "guest", "GUEST" },
                    { "a28842fe-fbe8-4004-a0e7-41826f8f608e", null, "admin", "ADMIN" },
                    { "cda84c47-3e55-4fa4-80fb-3d37e76cdfb8", null, "user", "USER" }
             });
      }
   }
}
