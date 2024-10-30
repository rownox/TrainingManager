using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserAccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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
                    { "5f019bca-54d2-4773-961d-b1d463c52d4e", null, "guest", "GUEST" },
                    { "c94c4a49-9277-4aba-b4c1-2259653f7467", null, "user", "USER" },
                    { "cd2fb9f0-28dc-41e6-8806-63d685e25ac8", null, "admin", "ADMIN" },
                    { "f517db22-3dc2-4942-959e-78709f9a531b", null, "owner", "OWNER" }
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
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders",
                column: "ParentSkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserAccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserAccountId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f019bca-54d2-4773-961d-b1d463c52d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c94c4a49-9277-4aba-b4c1-2259653f7467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd2fb9f0-28dc-41e6-8806-63d685e25ac8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f517db22-3dc2-4942-959e-78709f9a531b");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                    { "26fb1bef-f0de-41a1-b2aa-557c695da631", null, "admin", "ADMIN" },
                    { "4770d226-8abb-4012-8556-eeef905e596c", null, "guest", "GUEST" },
                    { "4d68d7a0-ecdc-45ba-a931-1f9c66112e5e", null, "owner", "OWNER" },
                    { "de1fa438-96b0-4bae-9c82-04d18639d22e", null, "user", "USER" }
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
                name: "FK_TrainingOrders_Skills_ParentSkillId",
                table: "TrainingOrders",
                column: "ParentSkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
