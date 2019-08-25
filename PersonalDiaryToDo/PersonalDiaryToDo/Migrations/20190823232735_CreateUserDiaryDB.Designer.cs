﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalDiaryToDo.Models;

namespace PersonalDiaryToDo.Migrations
{
    [DbContext(typeof(UserDiaryContext))]
    [Migration("20190823232735_CreateUserDiaryDB")]
    partial class CreateUserDiaryDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalDiaryToDo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Magdy", LastName = "Hussien" }
                    );
                });

            modelBuilder.Entity("PersonalDiaryToDo.Models.UserDiary", b =>
                {
                    b.Property<int>("UserDiaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DiaryDataTime");

                    b.Property<string>("DiaryImage");

                    b.Property<string>("DiaryText")
                        .HasMaxLength(500);

                    b.Property<DateTime>("InsertionDate");

                    b.Property<int>("UserId");

                    b.HasKey("UserDiaryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiaries");

                    b.HasData(
                        new { UserDiaryId = 1, DiaryDataTime = new DateTime(2019, 8, 24, 1, 27, 34, 893, DateTimeKind.Local), DiaryImage = "", DiaryText = "Go To Party", InsertionDate = new DateTime(2019, 8, 24, 1, 27, 34, 894, DateTimeKind.Local), UserId = 1 }
                    );
                });

            modelBuilder.Entity("PersonalDiaryToDo.Models.UserDiary", b =>
                {
                    b.HasOne("PersonalDiaryToDo.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
