using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalDiaryToDo.Migrations
{
    public partial class renametables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiaries_Users_UserId",
                table: "UserDiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiaries",
                table: "UserDiaries");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserDiaries",
                newName: "UserDiary");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiaries_UserId",
                table: "UserDiary",
                newName: "IX_UserDiary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiary",
                table: "UserDiary",
                column: "UserDiaryId");

            migrationBuilder.UpdateData(
                table: "UserDiary",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 24, 16, 14, 35, 968, DateTimeKind.Local), new DateTime(2019, 8, 24, 16, 14, 35, 982, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiary_User_UserId",
                table: "UserDiary",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiary_User_UserId",
                table: "UserDiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiary",
                table: "UserDiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserDiary",
                newName: "UserDiaries");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiary_UserId",
                table: "UserDiaries",
                newName: "IX_UserDiaries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiaries",
                table: "UserDiaries",
                column: "UserDiaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 24, 15, 38, 3, 368, DateTimeKind.Local), new DateTime(2019, 8, 24, 15, 38, 3, 392, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiaries_Users_UserId",
                table: "UserDiaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
