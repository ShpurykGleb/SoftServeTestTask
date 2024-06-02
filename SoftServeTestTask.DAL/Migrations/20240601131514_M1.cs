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
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
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
                    Gender = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GPA = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Group = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThirdName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcademicDegree = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
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
                    { 1, "Description of Course 1", "Course 1" },
                    { 2, "Description of Course 2", "Course 2" },
                    { 3, "Description of Course 3", "Course 3" },
                    { 4, "Description of Course 4", "Course 4" },
                    { 5, "Description of Course 5", "Course 5" },
                    { 6, "Description of Course 6", "Course 6" },
                    { 7, "Description of Course 7", "Course 7" },
                    { 8, "Description of Course 8", "Course 8" },
                    { 9, "Description of Course 9", "Course 9" },
                    { 10, "Description of Course 10", "Course 10" },
                    { 11, "Description of Course 11", "Course 11" },
                    { 12, "Description of Course 12", "Course 12" },
                    { 13, "Description of Course 13", "Course 13" },
                    { 14, "Description of Course 14", "Course 14" },
                    { 15, "Description of Course 15", "Course 15" },
                    { 16, "Description of Course 16", "Course 16" },
                    { 17, "Description of Course 17", "Course 17" },
                    { 18, "Description of Course 18", "Course 18" },
                    { 19, "Description of Course 19", "Course 19" },
                    { 20, "Description of Course 20", "Course 20" },
                    { 21, "Description of Course 21", "Course 21" },
                    { 22, "Description of Course 22", "Course 22" },
                    { 23, "Description of Course 23", "Course 23" },
                    { 24, "Description of Course 24", "Course 24" },
                    { 25, "Description of Course 25", "Course 25" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "FirstName", "GPA", "Gender", "Group", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, 19, "StudentFirstName1", 3.5m, "Female", "Group2", "StudentSecondName1", "StudentThirdName1" },
                    { 2, 20, "StudentFirstName2", 3.0m, "Male", "Group3", "StudentSecondName2", "StudentThirdName2" },
                    { 3, 21, "StudentFirstName3", 3.5m, "Female", "Group4", "StudentSecondName3", "StudentThirdName3" },
                    { 4, 22, "StudentFirstName4", 3.0m, "Male", "Group5", "StudentSecondName4", "StudentThirdName4" },
                    { 5, 18, "StudentFirstName5", 3.5m, "Female", "Group1", "StudentSecondName5", "StudentThirdName5" },
                    { 6, 19, "StudentFirstName6", 3.0m, "Male", "Group2", "StudentSecondName6", "StudentThirdName6" },
                    { 7, 20, "StudentFirstName7", 3.5m, "Female", "Group3", "StudentSecondName7", "StudentThirdName7" },
                    { 8, 21, "StudentFirstName8", 3.0m, "Male", "Group4", "StudentSecondName8", "StudentThirdName8" },
                    { 9, 22, "StudentFirstName9", 3.5m, "Female", "Group5", "StudentSecondName9", "StudentThirdName9" },
                    { 10, 18, "StudentFirstName10", 3.0m, "Male", "Group1", "StudentSecondName10", "StudentThirdName10" },
                    { 11, 19, "StudentFirstName11", 3.5m, "Female", "Group2", "StudentSecondName11", "StudentThirdName11" },
                    { 12, 20, "StudentFirstName12", 3.0m, "Male", "Group3", "StudentSecondName12", "StudentThirdName12" },
                    { 13, 21, "StudentFirstName13", 3.5m, "Female", "Group4", "StudentSecondName13", "StudentThirdName13" },
                    { 14, 22, "StudentFirstName14", 3.0m, "Male", "Group5", "StudentSecondName14", "StudentThirdName14" },
                    { 15, 18, "StudentFirstName15", 3.5m, "Female", "Group1", "StudentSecondName15", "StudentThirdName15" },
                    { 16, 19, "StudentFirstName16", 3.0m, "Male", "Group2", "StudentSecondName16", "StudentThirdName16" },
                    { 17, 20, "StudentFirstName17", 3.5m, "Female", "Group3", "StudentSecondName17", "StudentThirdName17" },
                    { 18, 21, "StudentFirstName18", 3.0m, "Male", "Group4", "StudentSecondName18", "StudentThirdName18" },
                    { 19, 22, "StudentFirstName19", 3.5m, "Female", "Group5", "StudentSecondName19", "StudentThirdName19" },
                    { 20, 18, "StudentFirstName20", 3.0m, "Male", "Group1", "StudentSecondName20", "StudentThirdName20" },
                    { 21, 19, "StudentFirstName21", 3.5m, "Female", "Group2", "StudentSecondName21", "StudentThirdName21" },
                    { 22, 20, "StudentFirstName22", 3.0m, "Male", "Group3", "StudentSecondName22", "StudentThirdName22" },
                    { 23, 21, "StudentFirstName23", 3.5m, "Female", "Group4", "StudentSecondName23", "StudentThirdName23" },
                    { 24, 22, "StudentFirstName24", 3.0m, "Male", "Group5", "StudentSecondName24", "StudentThirdName24" },
                    { 25, 18, "StudentFirstName25", 3.5m, "Female", "Group1", "StudentSecondName25", "StudentThirdName25" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AcademicDegree", "Age", "ExperienceYears", "FirstName", "Gender", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, "Degree 1", 26, 6, "FirstName1", "Female", "SecondName1", "ThirdName1" },
                    { 2, "Degree 2", 27, 7, "FirstName2", "Male", "SecondName2", "ThirdName2" },
                    { 3, "Degree 3", 28, 8, "FirstName3", "Female", "SecondName3", "ThirdName3" },
                    { 4, "Degree 4", 29, 9, "FirstName4", "Male", "SecondName4", "ThirdName4" },
                    { 5, "Degree 5", 30, 10, "FirstName5", "Female", "SecondName5", "ThirdName5" },
                    { 6, "Degree 6", 31, 11, "FirstName6", "Male", "SecondName6", "ThirdName6" },
                    { 7, "Degree 7", 32, 12, "FirstName7", "Female", "SecondName7", "ThirdName7" },
                    { 8, "Degree 8", 33, 13, "FirstName8", "Male", "SecondName8", "ThirdName8" },
                    { 9, "Degree 9", 34, 14, "FirstName9", "Female", "SecondName9", "ThirdName9" },
                    { 10, "Degree 10", 35, 15, "FirstName10", "Male", "SecondName10", "ThirdName10" },
                    { 11, "Degree 11", 36, 16, "FirstName11", "Female", "SecondName11", "ThirdName11" },
                    { 12, "Degree 12", 37, 17, "FirstName12", "Male", "SecondName12", "ThirdName12" },
                    { 13, "Degree 13", 38, 18, "FirstName13", "Female", "SecondName13", "ThirdName13" },
                    { 14, "Degree 14", 39, 19, "FirstName14", "Male", "SecondName14", "ThirdName14" },
                    { 15, "Degree 15", 40, 20, "FirstName15", "Female", "SecondName15", "ThirdName15" },
                    { 16, "Degree 16", 41, 21, "FirstName16", "Male", "SecondName16", "ThirdName16" },
                    { 17, "Degree 17", 42, 22, "FirstName17", "Female", "SecondName17", "ThirdName17" },
                    { 18, "Degree 18", 43, 23, "FirstName18", "Male", "SecondName18", "ThirdName18" },
                    { 19, "Degree 19", 44, 24, "FirstName19", "Female", "SecondName19", "ThirdName19" },
                    { 20, "Degree 20", 45, 25, "FirstName20", "Male", "SecondName20", "ThirdName20" },
                    { 21, "Degree 21", 46, 26, "FirstName21", "Female", "SecondName21", "ThirdName21" },
                    { 22, "Degree 22", 47, 27, "FirstName22", "Male", "SecondName22", "ThirdName22" },
                    { 23, "Degree 23", 48, 28, "FirstName23", "Female", "SecondName23", "ThirdName23" },
                    { 24, "Degree 24", 49, 29, "FirstName24", "Male", "SecondName24", "ThirdName24" },
                    { 25, "Degree 25", 50, 30, "FirstName25", "Female", "SecondName25", "ThirdName25" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");
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
        }
    }
}
