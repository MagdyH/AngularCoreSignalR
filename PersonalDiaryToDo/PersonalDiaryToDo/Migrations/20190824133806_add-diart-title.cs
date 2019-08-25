using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalDiaryToDo.Migrations
{
    public partial class adddiarttitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaryTitle",
                table: "UserDiaries",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 24, 15, 38, 3, 368, DateTimeKind.Local), new DateTime(2019, 8, 24, 15, 38, 3, 392, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaryTitle",
                table: "UserDiaries");

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "UserDiaryId",
                keyValue: 1,
                columns: new[] { "DiaryDataTime", "InsertionDate" },
                values: new object[] { new DateTime(2019, 8, 24, 1, 27, 34, 893, DateTimeKind.Local), new DateTime(2019, 8, 24, 1, 27, 34, 894, DateTimeKind.Local) });
        }
    }
}
