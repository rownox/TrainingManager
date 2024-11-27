using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _7 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Descriptions_ImageUploads_ImageUploadId",
             table: "Descriptions");

         migrationBuilder.DropIndex(
             name: "IX_Descriptions_ImageUploadId",
             table: "Descriptions");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "310c15ea-cef5-4b5d-9e21-2dd2da517a7b");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "3294fd93-e7a2-4341-9a14-30fd1ecd9789");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "95786b16-d958-40ef-b5b3-00f9e349ed16");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "f5e1b5ac-81a9-4b98-8ddb-0a46af450308");

         migrationBuilder.AddColumn<int>(
             name: "DescriptionId",
             table: "ImageUploads",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "46de173c-378f-4f57-9456-18941690dc9a", null, "guest", "GUEST" },
                    { "98fad56d-8806-4d97-bf6d-abe02ca36cc5", null, "owner", "OWNER" },
                    { "b1479489-3a6c-498b-8b7b-0d6854c2ff82", null, "admin", "ADMIN" },
                    { "dcbad8c5-ccea-40ae-b738-5c4f8b82e4b5", null, "user", "USER" }
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

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_ImageUploads_Descriptions_DescriptionId",
             table: "ImageUploads");

         migrationBuilder.DropIndex(
             name: "IX_ImageUploads_DescriptionId",
             table: "ImageUploads");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "46de173c-378f-4f57-9456-18941690dc9a");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "98fad56d-8806-4d97-bf6d-abe02ca36cc5");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "b1479489-3a6c-498b-8b7b-0d6854c2ff82");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "dcbad8c5-ccea-40ae-b738-5c4f8b82e4b5");

         migrationBuilder.DropColumn(
             name: "DescriptionId",
             table: "ImageUploads");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "310c15ea-cef5-4b5d-9e21-2dd2da517a7b", null, "admin", "ADMIN" },
                    { "3294fd93-e7a2-4341-9a14-30fd1ecd9789", null, "owner", "OWNER" },
                    { "95786b16-d958-40ef-b5b3-00f9e349ed16", null, "guest", "GUEST" },
                    { "f5e1b5ac-81a9-4b98-8ddb-0a46af450308", null, "user", "USER" }
             });

         migrationBuilder.CreateIndex(
             name: "IX_Descriptions_ImageUploadId",
             table: "Descriptions",
             column: "ImageUploadId");

         migrationBuilder.AddForeignKey(
             name: "FK_Descriptions_ImageUploads_ImageUploadId",
             table: "Descriptions",
             column: "ImageUploadId",
             principalTable: "ImageUploads",
             principalColumn: "Id");
      }
   }
}
