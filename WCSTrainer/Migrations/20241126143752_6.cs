using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations {
   /// <inheritdoc />
   public partial class _6 : Migration {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder) {
         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "2df59cca-1702-4a9d-a19f-6ca2134ccbd5");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "329bacd2-0528-488f-8831-4a534ffc09f7");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "9eeee3dd-1e52-44bb-97b7-9e50a694715a");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "ebc03303-165d-45d7-bbcc-3d4ab2ff0947");

         migrationBuilder.DropColumn(
             name: "Content",
             table: "Descriptions");

         migrationBuilder.RenameColumn(
             name: "FilePath",
             table: "Descriptions",
             newName: "TextContent");

         migrationBuilder.AddColumn<int>(
             name: "DescriptionType",
             table: "Descriptions",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.AddColumn<int>(
             name: "ImageUploadId",
             table: "Descriptions",
             type: "int",
             nullable: true);

         migrationBuilder.CreateTable(
             name: "ImageUploads",
             columns: table => new {
                Id = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FileSize = table.Column<long>(type: "bigint", nullable: false),
                FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
             },
             constraints: table => {
                table.PrimaryKey("PK_ImageUploads", x => x.Id);
             });

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

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
         migrationBuilder.DropForeignKey(
             name: "FK_Descriptions_ImageUploads_ImageUploadId",
             table: "Descriptions");

         migrationBuilder.DropTable(
             name: "ImageUploads");

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

         migrationBuilder.DropColumn(
             name: "DescriptionType",
             table: "Descriptions");

         migrationBuilder.DropColumn(
             name: "ImageUploadId",
             table: "Descriptions");

         migrationBuilder.RenameColumn(
             name: "TextContent",
             table: "Descriptions",
             newName: "FilePath");

         migrationBuilder.AddColumn<string>(
             name: "Content",
             table: "Descriptions",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "2df59cca-1702-4a9d-a19f-6ca2134ccbd5", null, "admin", "ADMIN" },
                    { "329bacd2-0528-488f-8831-4a534ffc09f7", null, "owner", "OWNER" },
                    { "9eeee3dd-1e52-44bb-97b7-9e50a694715a", null, "user", "USER" },
                    { "ebc03303-165d-45d7-bbcc-3d4ab2ff0947", null, "guest", "GUEST" }
             });
      }
   }
}
