using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalDiaryToDo.Migrations
{
    public partial class CreateUserDiaryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDiaries",
                columns: table => new
                {
                    UserDiaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaryText = table.Column<string>(maxLength: 500, nullable: true),
                    DiaryDataTime = table.Column<DateTime>(nullable: false),
                    DiaryImage = table.Column<string>(nullable: true),
                    InsertionDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiaries", x => x.UserDiaryId);
                    table.ForeignKey(
                        name: "FK_UserDiaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Magdy", "Hussien" });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "UserDiaryId", "DiaryDataTime", "DiaryImage", "DiaryText", "InsertionDate", "UserId" },
                values: new object[] { 1, new DateTime(2019, 8, 24, 1, 27, 34, 893, DateTimeKind.Local), "", "Go To Party", new DateTime(2019, 8, 24, 1, 27, 34, 894, DateTimeKind.Local), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiaries_UserId",
                table: "UserDiaries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiaries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
