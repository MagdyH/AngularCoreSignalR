using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalDiaryToDo.Migrations
{
    public partial class updateuserdiarytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaryText",
                table: "UserDiary");

            migrationBuilder.RenameColumn(
                name: "DiaryImage",
                table: "UserDiary",
                newName: "DiaryContent");

            migrationBuilder.UpdateData(
                table: "UserDiary",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "DiaryTitle", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 25, 1, 3, 56, 610, DateTimeKind.Local), "Go To Party", new DateTime(2019, 8, 25, 1, 3, 56, 621, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaryContent",
                table: "UserDiary",
                newName: "DiaryImage");

            migrationBuilder.AddColumn<string>(
                name: "DiaryText",
                table: "UserDiary",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserDiary",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "DiaryText", "DiaryTitle", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 24, 16, 14, 35, 968, DateTimeKind.Local), "Go To Party", null, new DateTime(2019, 8, 24, 16, 14, 35, 982, DateTimeKind.Local) });
        }
    }
}
