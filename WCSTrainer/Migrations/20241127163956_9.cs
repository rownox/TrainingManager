using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _9 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_ImageUploads_Descriptions_DescriptionId",
             table: "ImageUploads");

         migrationBuilder.DropPrimaryKey(
             name: "PK_ImageUploads",
             table: "ImageUploads");

         migrationBuilder.DropIndex(
             name: "IX_ImageUploads_DescriptionId",
             table: "ImageUploads");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "0eaf5a21-9307-4fc9-911d-f3216d8e1dbc");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "4d0e87cf-c434-43d3-a635-644f920ca6bc");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "5df5929e-990d-4432-9257-08a9951356b2");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "9693aa2c-72ee-4ace-9d48-5d1fdf6c9867");

         migrationBuilder.DropColumn(
             name: "DescriptionId",
             table: "ImageUploads");

         migrationBuilder.RenameTable(
             name: "ImageUploads",
             newName: "ImageUpload");

         migrationBuilder.AddPrimaryKey(
             name: "PK_ImageUpload",
             table: "ImageUpload",
             column: "Id");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "3237ab2a-91a8-4142-9071-54493b13c219", null, "user", "USER" },
                    { "5c8831ae-c175-411d-9dd8-f7176b82b451", null, "guest", "GUEST" },
                    { "5e4f46cb-ee4f-4f70-a990-0f6657499dea", null, "admin", "ADMIN" },
                    { "d17372bc-1354-4b70-94e8-8c888e5d07c8", null, "owner", "OWNER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_Descriptions_ImageUploadId",
             table: "Descriptions",
             column: "ImageUploadId");

         migrationBuilder.AddForeignKey(
             name: "FK_Descriptions_ImageUpload_ImageUploadId",
             table: "Descriptions",
             column: "ImageUploadId",
             principalTable: "ImageUpload",
             principalColumn: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Descriptions_ImageUpload_ImageUploadId",
             table: "Descriptions");

         migrationBuilder.DropIndex(
             name: "IX_Descriptions_ImageUploadId",
             table: "Descriptions");

         migrationBuilder.DropPrimaryKey(
             name: "PK_ImageUpload",
             table: "ImageUpload");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "3237ab2a-91a8-4142-9071-54493b13c219");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "5c8831ae-c175-411d-9dd8-f7176b82b451");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "5e4f46cb-ee4f-4f70-a990-0f6657499dea");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "d17372bc-1354-4b70-94e8-8c888e5d07c8");

         migrationBuilder.RenameTable(
             name: "ImageUpload",
             newName: "ImageUploads");

         migrationBuilder.AddColumn<int>(
             name: "DescriptionId",
             table: "ImageUploads",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.AddPrimaryKey(
             name: "PK_ImageUploads",
             table: "ImageUploads",
             column: "Id");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "0eaf5a21-9307-4fc9-911d-f3216d8e1dbc", null, "user", "USER" },
                    { "4d0e87cf-c434-43d3-a635-644f920ca6bc", null, "guest", "GUEST" },
                    { "5df5929e-990d-4432-9257-08a9951356b2", null, "owner", "OWNER" },
                    { "9693aa2c-72ee-4ace-9d48-5d1fdf6c9867", null, "admin", "ADMIN" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_ImageUploads_DescriptionId",
             table: "ImageUploads",
             column: "DescriptionId",
             unique: true);

         migrationBuilder.AddForeignKey(
             name: "FK_ImageUploads_Descriptions_DescriptionId",
             table: "ImageUploads",
             column: "DescriptionId",
             principalTable: "Descriptions",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }
   }
}
