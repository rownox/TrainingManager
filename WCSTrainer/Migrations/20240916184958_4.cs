using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WCSTrainer.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_TrainerGroupId",
                table: "EmployeeTrainerGroup");

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

            migrationBuilder.RenameColumn(
                name: "TrainerGroupId",
                table: "EmployeeTrainerGroup",
                newName: "GroupsId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25b381c7-2e76-4cee-96aa-6e8781773d84", null, "trainer", "TRAINER" },
                    { "4bb07a97-352f-4afd-a998-0adf40eece7d", null, "trainee", "TRAINEE" },
                    { "56021199-eccb-4d65-8953-a1198ffd53d0", null, "admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_GroupsId",
                table: "EmployeeTrainerGroup",
                column: "GroupsId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_GroupsId",
                table: "EmployeeTrainerGroup");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25b381c7-2e76-4cee-96aa-6e8781773d84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb07a97-352f-4afd-a998-0adf40eece7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56021199-eccb-4d65-8953-a1198ffd53d0");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "EmployeeTrainerGroup",
                newName: "TrainerGroupId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7efceb19-1b44-4130-a183-9f93bb03d544", null, "trainer", "TRAINER" },
                    { "e5485fae-9bab-4483-b3b5-76623c31bdf5", null, "admin", "ADMIN" },
                    { "f36c38fc-2a0b-4a59-b79a-aa2fe312705f", null, "trainee", "TRAINEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrainerGroup_TrainerGroups_TrainerGroupId",
                table: "EmployeeTrainerGroup",
                column: "TrainerGroupId",
                principalTable: "TrainerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
