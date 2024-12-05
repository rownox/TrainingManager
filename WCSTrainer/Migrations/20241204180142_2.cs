using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _2 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
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
             name: "Department",
             table: "Employees",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "aa42f9df-cef1-40b1-b670-ad53a8915e2e", null, "admin", "ADMIN" },
                    { "d1b5a8a4-a080-4a82-9b32-9fb16fb1690a", null, "user", "USER" },
                    { "e66b4c96-c925-44c1-b00b-e3c80c957281", null, "guest", "GUEST" },
                    { "edc22682-7157-488b-8bf8-87c00d42b584", null, "owner", "OWNER" }
             });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "aa42f9df-cef1-40b1-b670-ad53a8915e2e");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "d1b5a8a4-a080-4a82-9b32-9fb16fb1690a");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "e66b4c96-c925-44c1-b00b-e3c80c957281");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "edc22682-7157-488b-8bf8-87c00d42b584");

         migrationBuilder.DropColumn(
             name: "Department",
             table: "Employees");

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
   }
}
