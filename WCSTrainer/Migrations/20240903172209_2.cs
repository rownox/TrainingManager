using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _2 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_AspNetUsers_Employees_EmployeeId",
             table: "AspNetUsers");

         migrationBuilder.DropIndex(
             name: "IX_AspNetUsers_EmployeeId",
             table: "AspNetUsers");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "6e8869bc-8e1f-4e7f-b2f9-97bc6081273f");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "91853c95-da9c-426f-998c-9feebf15aa02");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "d68a7a40-d4fb-48c1-91f3-23a21d19c575");

         migrationBuilder.AlterColumn<string>(
             name: "UserAccountId",
             table: "Employees",
             type: "nvarchar(450)",
             nullable: false,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "7a76adca-53f0-4bbd-83c8-9f5b61b301ea", null, "trainee", "TRAINEE" },
                    { "d19766d8-f4ce-4b63-97c6-4608abc0e787", null, "admin", "ADMIN" },
                    { "ed76cf48-f427-4d98-ae91-9aad38d2ed74", null, "trainer", "TRAINER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_Employees_UserAccountId",
             table: "Employees",
             column: "UserAccountId",
             unique: true);

         migrationBuilder.AddForeignKey(
             name: "FK_Employees_AspNetUsers_UserAccountId",
             table: "Employees",
             column: "UserAccountId",
             principalTable: "AspNetUsers",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Employees_AspNetUsers_UserAccountId",
             table: "Employees");

         migrationBuilder.DropIndex(
             name: "IX_Employees_UserAccountId",
             table: "Employees");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "7a76adca-53f0-4bbd-83c8-9f5b61b301ea");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "d19766d8-f4ce-4b63-97c6-4608abc0e787");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "ed76cf48-f427-4d98-ae91-9aad38d2ed74");

         migrationBuilder.AlterColumn<string>(
             name: "UserAccountId",
             table: "Employees",
             type: "nvarchar(max)",
             nullable: false,
             oldClrType: typeof(string),
             oldType: "nvarchar(450)");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "6e8869bc-8e1f-4e7f-b2f9-97bc6081273f", null, "trainee", "TRAINEE" },
                    { "91853c95-da9c-426f-998c-9feebf15aa02", null, "admin", "ADMIN" },
                    { "d68a7a40-d4fb-48c1-91f3-23a21d19c575", null, "trainer", "TRAINER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_AspNetUsers_EmployeeId",
             table: "AspNetUsers",
             column: "EmployeeId",
             unique: true);

         migrationBuilder.AddForeignKey(
             name: "FK_AspNetUsers_Employees_EmployeeId",
             table: "AspNetUsers",
             column: "EmployeeId",
             principalTable: "Employees",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }
   }
}
