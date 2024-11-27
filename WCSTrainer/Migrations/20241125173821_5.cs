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
             keyValue: "49376fa8-8a03-4cda-8a22-b88e61abc37c");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "c0af030f-84a9-4891-8efe-e38356cc4481");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "c8e784b7-7bc0-46bd-8c39-5d0cbe7b7129");

         migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValue: "fd692f8d-173d-4125-b022-93315fab7c55");

         migrationBuilder.DropColumn(
             name: "Column",
             table: "Descriptions");

         migrationBuilder.DropColumn(
             name: "Data",
             table: "Descriptions");

         migrationBuilder.DropColumn(
             name: "Row",
             table: "Descriptions");

         migrationBuilder.DropColumn(
             name: "Type",
             table: "Descriptions");

         migrationBuilder.RenameColumn(
             name: "ContentType",
             table: "Descriptions",
             newName: "FilePath");

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

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder) {
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

         migrationBuilder.RenameColumn(
             name: "FilePath",
             table: "Descriptions",
             newName: "ContentType");

         migrationBuilder.AddColumn<int>(
             name: "Column",
             table: "Descriptions",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.AddColumn<byte[]>(
             name: "Data",
             table: "Descriptions",
             type: "varbinary(max)",
             nullable: true);

         migrationBuilder.AddColumn<int>(
             name: "Row",
             table: "Descriptions",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.AddColumn<int>(
             name: "Type",
             table: "Descriptions",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
             values: new object[,]
             {
                    { "49376fa8-8a03-4cda-8a22-b88e61abc37c", null, "user", "USER" },
                    { "c0af030f-84a9-4891-8efe-e38356cc4481", null, "admin", "ADMIN" },
                    { "c8e784b7-7bc0-46bd-8c39-5d0cbe7b7129", null, "owner", "OWNER" },
                    { "fd692f8d-173d-4125-b022-93315fab7c55", null, "guest", "GUEST" }
             });
      }
   }
}
