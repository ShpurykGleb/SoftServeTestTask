using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftServeTestTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThirdName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeacherContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherContacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeachersInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThirdName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersInfoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Group = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudentContacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "StudentContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_StudentInfoes_InfoId",
                        column: x => x.InfoId,
                        principalTable: "StudentInfoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    AcademicDegree = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_TeacherContacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "TeacherContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_TeachersInfoes_InfoId",
                        column: x => x.InfoId,
                        principalTable: "TeachersInfoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "1 course description", "1 course name" },
                    { 2, "2 course description", "2 course name" },
                    { 3, "3 course description", "3 course name" },
                    { 4, "4 course description", "4 course name" },
                    { 5, "5 course description", "5 course name" },
                    { 6, "6 course description", "6 course name" },
                    { 7, "7 course description", "7 course name" },
                    { 8, "8 course description", "8 course name" },
                    { 9, "9 course description", "9 course name" },
                    { 10, "10 course description", "10 course name" },
                    { 11, "11 course description", "11 course name" },
                    { 12, "12 course description", "12 course name" },
                    { 13, "13 course description", "13 course name" },
                    { 14, "14 course description", "14 course name" },
                    { 15, "15 course description", "15 course name" },
                    { 16, "16 course description", "16 course name" },
                    { 17, "17 course description", "17 course name" },
                    { 18, "18 course description", "18 course name" },
                    { 19, "19 course description", "19 course name" },
                    { 20, "20 course description", "20 course name" },
                    { 21, "21 course description", "21 course name" },
                    { 22, "22 course description", "22 course name" },
                    { 23, "23 course description", "23 course name" },
                    { 24, "24 course description", "24 course name" },
                    { 25, "25 course description", "25 course name" }
                });

            migrationBuilder.InsertData(
                table: "StudentContacts",
                columns: new[] { "Id", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "1 street, house 2", "student1@gmail.com", "+380001122334" },
                    { 2, "2 street, house 3", "student2@gmail.com", "+380001122334" },
                    { 3, "3 street, house 4", "student3@gmail.com", "+380001122334" },
                    { 4, "4 street, house 5", "student4@gmail.com", "+380001122334" },
                    { 5, "5 street, house 6", "student5@gmail.com", "+380001122334" },
                    { 6, "6 street, house 7", "student6@gmail.com", "+380001122334" },
                    { 7, "7 street, house 8", "student7@gmail.com", "+380001122334" },
                    { 8, "8 street, house 9", "student8@gmail.com", "+380001122334" },
                    { 9, "9 street, house 10", "student9@gmail.com", "+380001122334" },
                    { 10, "10 street, house 11", "student10@gmail.com", "+380001122334" },
                    { 11, "11 street, house 12", "student11@gmail.com", "+380001122334" },
                    { 12, "12 street, house 13", "student12@gmail.com", "+380001122334" },
                    { 13, "13 street, house 14", "student13@gmail.com", "+380001122334" },
                    { 14, "14 street, house 15", "student14@gmail.com", "+380001122334" },
                    { 15, "15 street, house 16", "student15@gmail.com", "+380001122334" },
                    { 16, "16 street, house 17", "student16@gmail.com", "+380001122334" },
                    { 17, "17 street, house 18", "student17@gmail.com", "+380001122334" },
                    { 18, "18 street, house 19", "student18@gmail.com", "+380001122334" },
                    { 19, "19 street, house 20", "student19@gmail.com", "+380001122334" },
                    { 20, "20 street, house 21", "student20@gmail.com", "+380001122334" },
                    { 21, "21 street, house 22", "student21@gmail.com", "+380001122334" },
                    { 22, "22 street, house 23", "student22@gmail.com", "+380001122334" },
                    { 23, "23 street, house 24", "student23@gmail.com", "+380001122334" },
                    { 24, "24 street, house 25", "student24@gmail.com", "+380001122334" },
                    { 25, "25 street, house 26", "student25@gmail.com", "+380001122334" }
                });

            migrationBuilder.InsertData(
                table: "StudentInfoes",
                columns: new[] { "Id", "Age", "BirthDate", "FirstName", "Gender", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, 19, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3149), "Student 1 first name", "1 gender", "Student 1 second name", "Student 1 third name" },
                    { 2, 20, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3157), "Student 2 first name", "2 gender", "Student 2 second name", "Student 2 third name" },
                    { 3, 21, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3162), "Student 3 first name", "3 gender", "Student 3 second name", "Student 3 third name" },
                    { 4, 22, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3167), "Student 4 first name", "4 gender", "Student 4 second name", "Student 4 third name" },
                    { 5, 23, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3172), "Student 5 first name", "5 gender", "Student 5 second name", "Student 5 third name" },
                    { 6, 24, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3178), "Student 6 first name", "6 gender", "Student 6 second name", "Student 6 third name" },
                    { 7, 25, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3183), "Student 7 first name", "7 gender", "Student 7 second name", "Student 7 third name" },
                    { 8, 26, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3188), "Student 8 first name", "8 gender", "Student 8 second name", "Student 8 third name" },
                    { 9, 27, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3193), "Student 9 first name", "9 gender", "Student 9 second name", "Student 9 third name" },
                    { 10, 28, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3199), "Student 10 first name", "10 gender", "Student 10 second name", "Student 10 third name" },
                    { 11, 29, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3220), "Student 11 first name", "11 gender", "Student 11 second name", "Student 11 third name" },
                    { 12, 30, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3225), "Student 12 first name", "12 gender", "Student 12 second name", "Student 12 third name" },
                    { 13, 31, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3230), "Student 13 first name", "13 gender", "Student 13 second name", "Student 13 third name" },
                    { 14, 32, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3235), "Student 14 first name", "14 gender", "Student 14 second name", "Student 14 third name" },
                    { 15, 33, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3240), "Student 15 first name", "15 gender", "Student 15 second name", "Student 15 third name" },
                    { 16, 34, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3245), "Student 16 first name", "16 gender", "Student 16 second name", "Student 16 third name" },
                    { 17, 35, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3250), "Student 17 first name", "17 gender", "Student 17 second name", "Student 17 third name" },
                    { 18, 36, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3256), "Student 18 first name", "18 gender", "Student 18 second name", "Student 18 third name" },
                    { 19, 37, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3261), "Student 19 first name", "19 gender", "Student 19 second name", "Student 19 third name" },
                    { 20, 38, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3266), "Student 20 first name", "20 gender", "Student 20 second name", "Student 20 third name" },
                    { 21, 39, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3271), "Student 21 first name", "21 gender", "Student 21 second name", "Student 21 third name" },
                    { 22, 40, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3276), "Student 22 first name", "22 gender", "Student 22 second name", "Student 22 third name" },
                    { 23, 41, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3281), "Student 23 first name", "23 gender", "Student 23 second name", "Student 23 third name" },
                    { 24, 42, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3285), "Student 24 first name", "24 gender", "Student 24 second name", "Student 24 third name" },
                    { 25, 43, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(3290), "Student 25 first name", "25 gender", "Student 25 second name", "Student 25 third name" }
                });

            migrationBuilder.InsertData(
                table: "TeacherContacts",
                columns: new[] { "Id", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "1 street, house 2", "teacher1@gmail.com", "+380001122334" },
                    { 2, "2 street, house 3", "teacher2@gmail.com", "+380001122334" },
                    { 3, "3 street, house 4", "teacher3@gmail.com", "+380001122334" },
                    { 4, "4 street, house 5", "teacher4@gmail.com", "+380001122334" },
                    { 5, "5 street, house 6", "teacher5@gmail.com", "+380001122334" },
                    { 6, "6 street, house 7", "teacher6@gmail.com", "+380001122334" },
                    { 7, "7 street, house 8", "teacher7@gmail.com", "+380001122334" },
                    { 8, "8 street, house 9", "teacher8@gmail.com", "+380001122334" },
                    { 9, "9 street, house 10", "teacher9@gmail.com", "+380001122334" },
                    { 10, "10 street, house 11", "teacher10@gmail.com", "+380001122334" },
                    { 11, "11 street, house 12", "teacher11@gmail.com", "+380001122334" },
                    { 12, "12 street, house 13", "teacher12@gmail.com", "+380001122334" },
                    { 13, "13 street, house 14", "teacher13@gmail.com", "+380001122334" },
                    { 14, "14 street, house 15", "teacher14@gmail.com", "+380001122334" },
                    { 15, "15 street, house 16", "teacher15@gmail.com", "+380001122334" },
                    { 16, "16 street, house 17", "teacher16@gmail.com", "+380001122334" },
                    { 17, "17 street, house 18", "teacher17@gmail.com", "+380001122334" },
                    { 18, "18 street, house 19", "teacher18@gmail.com", "+380001122334" },
                    { 19, "19 street, house 20", "teacher19@gmail.com", "+380001122334" },
                    { 20, "20 street, house 21", "teacher20@gmail.com", "+380001122334" },
                    { 21, "21 street, house 22", "teacher21@gmail.com", "+380001122334" },
                    { 22, "22 street, house 23", "teacher22@gmail.com", "+380001122334" },
                    { 23, "23 street, house 24", "teacher23@gmail.com", "+380001122334" },
                    { 24, "24 street, house 25", "teacher24@gmail.com", "+380001122334" },
                    { 25, "25 street, house 26", "teacher25@gmail.com", "+380001122334" }
                });

            migrationBuilder.InsertData(
                table: "TeachersInfoes",
                columns: new[] { "Id", "Age", "BirthDate", "FirstName", "Gender", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, 31, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2750), "Teacher 1 first name", "1 gender", "Teacher 1 second name", "Teacher 1 third name" },
                    { 2, 32, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2810), "Teacher 2 first name", "2 gender", "Teacher 2 second name", "Teacher 2 third name" },
                    { 3, 33, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2815), "Teacher 3 first name", "3 gender", "Teacher 3 second name", "Teacher 3 third name" },
                    { 4, 34, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2820), "Teacher 4 first name", "4 gender", "Teacher 4 second name", "Teacher 4 third name" },
                    { 5, 35, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2825), "Teacher 5 first name", "5 gender", "Teacher 5 second name", "Teacher 5 third name" },
                    { 6, 36, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2831), "Teacher 6 first name", "6 gender", "Teacher 6 second name", "Teacher 6 third name" },
                    { 7, 37, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2836), "Teacher 7 first name", "7 gender", "Teacher 7 second name", "Teacher 7 third name" },
                    { 8, 38, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2841), "Teacher 8 first name", "8 gender", "Teacher 8 second name", "Teacher 8 third name" },
                    { 9, 39, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2846), "Teacher 9 first name", "9 gender", "Teacher 9 second name", "Teacher 9 third name" },
                    { 10, 40, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2852), "Teacher 10 first name", "10 gender", "Teacher 10 second name", "Teacher 10 third name" },
                    { 11, 41, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2857), "Teacher 11 first name", "11 gender", "Teacher 11 second name", "Teacher 11 third name" },
                    { 12, 42, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2862), "Teacher 12 first name", "12 gender", "Teacher 12 second name", "Teacher 12 third name" },
                    { 13, 43, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2892), "Teacher 13 first name", "13 gender", "Teacher 13 second name", "Teacher 13 third name" },
                    { 14, 44, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2898), "Teacher 14 first name", "14 gender", "Teacher 14 second name", "Teacher 14 third name" },
                    { 15, 45, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2903), "Teacher 15 first name", "15 gender", "Teacher 15 second name", "Teacher 15 third name" },
                    { 16, 46, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2908), "Teacher 16 first name", "16 gender", "Teacher 16 second name", "Teacher 16 third name" },
                    { 17, 47, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2913), "Teacher 17 first name", "17 gender", "Teacher 17 second name", "Teacher 17 third name" },
                    { 18, 48, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2919), "Teacher 18 first name", "18 gender", "Teacher 18 second name", "Teacher 18 third name" },
                    { 19, 49, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2924), "Teacher 19 first name", "19 gender", "Teacher 19 second name", "Teacher 19 third name" },
                    { 20, 50, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2929), "Teacher 20 first name", "20 gender", "Teacher 20 second name", "Teacher 20 third name" },
                    { 21, 51, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2934), "Teacher 21 first name", "21 gender", "Teacher 21 second name", "Teacher 21 third name" },
                    { 22, 52, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2939), "Teacher 22 first name", "22 gender", "Teacher 22 second name", "Teacher 22 third name" },
                    { 23, 53, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2944), "Teacher 23 first name", "23 gender", "Teacher 23 second name", "Teacher 23 third name" },
                    { 24, 54, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2949), "Teacher 24 first name", "24 gender", "Teacher 24 second name", "Teacher 24 third name" },
                    { 25, 55, new DateTime(2024, 5, 29, 16, 35, 18, 761, DateTimeKind.Local).AddTicks(2954), "Teacher 25 first name", "25 gender", "Teacher 25 second name", "Teacher 25 third name" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ContactsId", "GPA", "Group", "InfoId" },
                values: new object[,]
                {
                    { 1, 1, 4.39946361486951m, "1 student group", 1 },
                    { 2, 2, 3.95830992712239m, "2 student group", 2 },
                    { 3, 3, 3.41656179618226m, "3 student group", 3 },
                    { 4, 4, 4.21644152362661m, "4 student group", 4 },
                    { 5, 5, 4.41139091002224m, "5 student group", 5 },
                    { 6, 6, 4.67222811402902m, "6 student group", 6 },
                    { 7, 7, 4.69012031106494m, "7 student group", 7 },
                    { 8, 8, 4.42230886963679m, "8 student group", 8 },
                    { 9, 9, 3.13993533679127m, "9 student group", 9 },
                    { 10, 10, 4.20548640980008m, "10 student group", 10 },
                    { 11, 11, 3.32415540778736m, "11 student group", 11 },
                    { 12, 12, 4.40205955065281m, "12 student group", 12 },
                    { 13, 13, 3.55284794449529m, "13 student group", 13 },
                    { 14, 14, 3.22907175912146m, "14 student group", 14 },
                    { 15, 15, 4.71708973626318m, "15 student group", 15 },
                    { 16, 16, 4.98728315948691m, "16 student group", 16 },
                    { 17, 17, 3.14275385818266m, "17 student group", 17 },
                    { 18, 18, 3.8072699242196m, "18 student group", 18 },
                    { 19, 19, 4.68863352862479m, "19 student group", 19 },
                    { 20, 20, 4.46710510721084m, "20 student group", 20 },
                    { 21, 21, 3.42166814674025m, "21 student group", 21 },
                    { 22, 22, 3.10086330575528m, "22 student group", 22 },
                    { 23, 23, 3.64849786346548m, "23 student group", 23 },
                    { 24, 24, 4.79349656500742m, "24 student group", 24 },
                    { 25, 25, 4.30885863712004m, "25 student group", 25 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AcademicDegree", "ContactsId", "ExperienceYears", "InfoId" },
                values: new object[,]
                {
                    { 1, "1 degree", 1, 2, 1 },
                    { 2, "2 degree", 2, 4, 2 },
                    { 3, "3 degree", 3, 6, 3 },
                    { 4, "4 degree", 4, 8, 4 },
                    { 5, "5 degree", 5, 10, 5 },
                    { 6, "6 degree", 6, 12, 6 },
                    { 7, "7 degree", 7, 14, 7 },
                    { 8, "8 degree", 8, 16, 8 },
                    { 9, "9 degree", 9, 18, 9 },
                    { 10, "10 degree", 10, 20, 10 },
                    { 11, "11 degree", 11, 22, 11 },
                    { 12, "12 degree", 12, 24, 12 },
                    { 13, "13 degree", 13, 26, 13 },
                    { 14, "14 degree", 14, 28, 14 },
                    { 15, "15 degree", 15, 30, 15 },
                    { 16, "16 degree", 16, 32, 16 },
                    { 17, "17 degree", 17, 34, 17 },
                    { 18, "18 degree", 18, 36, 18 },
                    { 19, "19 degree", 19, 38, 19 },
                    { 20, "20 degree", 20, 40, 20 },
                    { 21, "21 degree", 21, 42, 21 },
                    { 22, "22 degree", 22, 44, 22 },
                    { 23, "23 degree", 23, 46, 23 },
                    { 24, "24 degree", 24, 48, 24 },
                    { 25, "25 degree", 25, 50, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContactsId",
                table: "Students",
                column: "ContactsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_InfoId",
                table: "Students",
                column: "InfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ContactsId",
                table: "Teachers",
                column: "ContactsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_InfoId",
                table: "Teachers",
                column: "InfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "StudentContacts");

            migrationBuilder.DropTable(
                name: "StudentInfoes");

            migrationBuilder.DropTable(
                name: "TeacherContacts");

            migrationBuilder.DropTable(
                name: "TeachersInfoes");
        }
    }
}
