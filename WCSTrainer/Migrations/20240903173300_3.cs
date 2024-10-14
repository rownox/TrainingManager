using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _3 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Employees_AspNetUsers_UserAccountId",
             table: "Employees");

         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Locations_LocationId",
             table: "TrainingOrders");

         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Skills_ParentSkillId",
             table: "TrainingOrders");

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

         migrationBuilder.AlterColumn<int>(
             name: "ParentSkillId",
             table: "TrainingOrders",
             type: "int",
             nullable: true,
             oldClrType: typeof(int),
             oldType: "int");

         migrationBuilder.AlterColumn<int>(
             name: "LocationId",
             table: "TrainingOrders",
             type: "int",
             nullable: true,
             oldClrType: typeof(int),
             oldType: "int");

         migrationBuilder.AlterColumn<string>(
             name: "UserAccountId",
             table: "Employees",
             type: "nvarchar(450)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(450)");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "7efceb19-1b44-4130-a183-9f93bb03d544", null, "trainer", "TRAINER" },
                    { "e5485fae-9bab-4483-b3b5-76623c31bdf5", null, "admin", "ADMIN" },
                    { "f36c38fc-2a0b-4a59-b79a-aa2fe312705f", null, "trainee", "TRAINEE" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_Employees_UserAccountId",
             table: "Employees",
             column: "UserAccountId",
             unique: true,
             filter: "[UserAccountId] IS NOT NULL");

         migrationBuilder.AddForeignKey(
             name: "FK_Employees_AspNetUsers_UserAccountId",
             table: "Employees",
             column: "UserAccountId",
             principalTable: "AspNetUsers",
             principalColumn: "Id");

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Locations_LocationId",
             table: "TrainingOrders",
             column: "LocationId",
             principalTable: "Locations",
             principalColumn: "Id");

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Skills_ParentSkillId",
             table: "TrainingOrders",
             column: "ParentSkillId",
             principalTable: "Skills",
             principalColumn: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Employees_AspNetUsers_UserAccountId",
             table: "Employees");

         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Locations_LocationId",
             table: "TrainingOrders");

         migrationBuilder.DropForeignKey(
             name: "FK_TrainingOrders_Skills_ParentSkillId",
             table: "TrainingOrders");

         migrationBuilder.DropIndex(
             name: "IX_Employees_UserAccountId",
             table: "Employees");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "7efceb19-1b44-4130-a183-9f93bb03d544");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "e5485fae-9bab-4483-b3b5-76623c31bdf5");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "f36c38fc-2a0b-4a59-b79a-aa2fe312705f");

         migrationBuilder.AlterColumn<int>(
             name: "ParentSkillId",
             table: "TrainingOrders",
             type: "int",
             nullable: false,
             defaultValue: 0,
             oldClrType: typeof(int),
             oldType: "int",
             oldNullable: true);

         migrationBuilder.AlterColumn<int>(
             name: "LocationId",
             table: "TrainingOrders",
             type: "int",
             nullable: false,
             defaultValue: 0,
             oldClrType: typeof(int),
             oldType: "int",
             oldNullable: true);

         migrationBuilder.AlterColumn<string>(
             name: "UserAccountId",
             table: "Employees",
             type: "nvarchar(450)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(450)",
             oldNullable: true);

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

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Locations_LocationId",
             table: "TrainingOrders",
             column: "LocationId",
             principalTable: "Locations",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);

         migrationBuilder.AddForeignKey(
             name: "FK_TrainingOrders_Skills_ParentSkillId",
             table: "TrainingOrders",
             column: "ParentSkillId",
             principalTable: "Skills",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }
   }
}
