﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftServeTestTask.DAL.Database;

#nullable disable

namespace SoftServeTestTask.DAL.Migrations
{
    [DbContext(typeof(EducationalContext))]
    partial class EducationalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("SoftServeTestTask.DAL.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of Course 1",
                            Name = "Course 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of Course 2",
                            Name = "Course 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description of Course 3",
                            Name = "Course 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description of Course 4",
                            Name = "Course 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description of Course 5",
                            Name = "Course 5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description of Course 6",
                            Name = "Course 6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Description of Course 7",
                            Name = "Course 7"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Description of Course 8",
                            Name = "Course 8"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Description of Course 9",
                            Name = "Course 9"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Description of Course 10",
                            Name = "Course 10"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Description of Course 11",
                            Name = "Course 11"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Description of Course 12",
                            Name = "Course 12"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Description of Course 13",
                            Name = "Course 13"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Description of Course 14",
                            Name = "Course 14"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Description of Course 15",
                            Name = "Course 15"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Description of Course 16",
                            Name = "Course 16"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Description of Course 17",
                            Name = "Course 17"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Description of Course 18",
                            Name = "Course 18"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Description of Course 19",
                            Name = "Course 19"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Description of Course 20",
                            Name = "Course 20"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Description of Course 21",
                            Name = "Course 21"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Description of Course 22",
                            Name = "Course 22"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Description of Course 23",
                            Name = "Course 23"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Description of Course 24",
                            Name = "Course 24"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Description of Course 25",
                            Name = "Course 25"
                        });
                });

            modelBuilder.Entity("SoftServeTestTask.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("GPA")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 19,
                            FirstName = "StudentFirstName1",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group2",
                            SecondName = "StudentSecondName1",
                            ThirdName = "StudentThirdName1"
                        },
                        new
                        {
                            Id = 2,
                            Age = 20,
                            FirstName = "StudentFirstName2",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group3",
                            SecondName = "StudentSecondName2",
                            ThirdName = "StudentThirdName2"
                        },
                        new
                        {
                            Id = 3,
                            Age = 21,
                            FirstName = "StudentFirstName3",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group4",
                            SecondName = "StudentSecondName3",
                            ThirdName = "StudentThirdName3"
                        },
                        new
                        {
                            Id = 4,
                            Age = 22,
                            FirstName = "StudentFirstName4",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group5",
                            SecondName = "StudentSecondName4",
                            ThirdName = "StudentThirdName4"
                        },
                        new
                        {
                            Id = 5,
                            Age = 18,
                            FirstName = "StudentFirstName5",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group1",
                            SecondName = "StudentSecondName5",
                            ThirdName = "StudentThirdName5"
                        },
                        new
                        {
                            Id = 6,
                            Age = 19,
                            FirstName = "StudentFirstName6",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group2",
                            SecondName = "StudentSecondName6",
                            ThirdName = "StudentThirdName6"
                        },
                        new
                        {
                            Id = 7,
                            Age = 20,
                            FirstName = "StudentFirstName7",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group3",
                            SecondName = "StudentSecondName7",
                            ThirdName = "StudentThirdName7"
                        },
                        new
                        {
                            Id = 8,
                            Age = 21,
                            FirstName = "StudentFirstName8",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group4",
                            SecondName = "StudentSecondName8",
                            ThirdName = "StudentThirdName8"
                        },
                        new
                        {
                            Id = 9,
                            Age = 22,
                            FirstName = "StudentFirstName9",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group5",
                            SecondName = "StudentSecondName9",
                            ThirdName = "StudentThirdName9"
                        },
                        new
                        {
                            Id = 10,
                            Age = 18,
                            FirstName = "StudentFirstName10",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group1",
                            SecondName = "StudentSecondName10",
                            ThirdName = "StudentThirdName10"
                        },
                        new
                        {
                            Id = 11,
                            Age = 19,
                            FirstName = "StudentFirstName11",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group2",
                            SecondName = "StudentSecondName11",
                            ThirdName = "StudentThirdName11"
                        },
                        new
                        {
                            Id = 12,
                            Age = 20,
                            FirstName = "StudentFirstName12",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group3",
                            SecondName = "StudentSecondName12",
                            ThirdName = "StudentThirdName12"
                        },
                        new
                        {
                            Id = 13,
                            Age = 21,
                            FirstName = "StudentFirstName13",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group4",
                            SecondName = "StudentSecondName13",
                            ThirdName = "StudentThirdName13"
                        },
                        new
                        {
                            Id = 14,
                            Age = 22,
                            FirstName = "StudentFirstName14",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group5",
                            SecondName = "StudentSecondName14",
                            ThirdName = "StudentThirdName14"
                        },
                        new
                        {
                            Id = 15,
                            Age = 18,
                            FirstName = "StudentFirstName15",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group1",
                            SecondName = "StudentSecondName15",
                            ThirdName = "StudentThirdName15"
                        },
                        new
                        {
                            Id = 16,
                            Age = 19,
                            FirstName = "StudentFirstName16",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group2",
                            SecondName = "StudentSecondName16",
                            ThirdName = "StudentThirdName16"
                        },
                        new
                        {
                            Id = 17,
                            Age = 20,
                            FirstName = "StudentFirstName17",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group3",
                            SecondName = "StudentSecondName17",
                            ThirdName = "StudentThirdName17"
                        },
                        new
                        {
                            Id = 18,
                            Age = 21,
                            FirstName = "StudentFirstName18",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group4",
                            SecondName = "StudentSecondName18",
                            ThirdName = "StudentThirdName18"
                        },
                        new
                        {
                            Id = 19,
                            Age = 22,
                            FirstName = "StudentFirstName19",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group5",
                            SecondName = "StudentSecondName19",
                            ThirdName = "StudentThirdName19"
                        },
                        new
                        {
                            Id = 20,
                            Age = 18,
                            FirstName = "StudentFirstName20",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group1",
                            SecondName = "StudentSecondName20",
                            ThirdName = "StudentThirdName20"
                        },
                        new
                        {
                            Id = 21,
                            Age = 19,
                            FirstName = "StudentFirstName21",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group2",
                            SecondName = "StudentSecondName21",
                            ThirdName = "StudentThirdName21"
                        },
                        new
                        {
                            Id = 22,
                            Age = 20,
                            FirstName = "StudentFirstName22",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group3",
                            SecondName = "StudentSecondName22",
                            ThirdName = "StudentThirdName22"
                        },
                        new
                        {
                            Id = 23,
                            Age = 21,
                            FirstName = "StudentFirstName23",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group4",
                            SecondName = "StudentSecondName23",
                            ThirdName = "StudentThirdName23"
                        },
                        new
                        {
                            Id = 24,
                            Age = 22,
                            FirstName = "StudentFirstName24",
                            GPA = 3.0m,
                            Gender = "Male",
                            Group = "Group5",
                            SecondName = "StudentSecondName24",
                            ThirdName = "StudentThirdName24"
                        },
                        new
                        {
                            Id = 25,
                            Age = 18,
                            FirstName = "StudentFirstName25",
                            GPA = 3.5m,
                            Gender = "Female",
                            Group = "Group1",
                            SecondName = "StudentSecondName25",
                            ThirdName = "StudentThirdName25"
                        });
                });

            modelBuilder.Entity("SoftServeTestTask.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicDegree")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicDegree = "Degree 1",
                            Age = 26,
                            ExperienceYears = 6,
                            FirstName = "FirstName1",
                            Gender = "Female",
                            SecondName = "SecondName1",
                            ThirdName = "ThirdName1"
                        },
                        new
                        {
                            Id = 2,
                            AcademicDegree = "Degree 2",
                            Age = 27,
                            ExperienceYears = 7,
                            FirstName = "FirstName2",
                            Gender = "Male",
                            SecondName = "SecondName2",
                            ThirdName = "ThirdName2"
                        },
                        new
                        {
                            Id = 3,
                            AcademicDegree = "Degree 3",
                            Age = 28,
                            ExperienceYears = 8,
                            FirstName = "FirstName3",
                            Gender = "Female",
                            SecondName = "SecondName3",
                            ThirdName = "ThirdName3"
                        },
                        new
                        {
                            Id = 4,
                            AcademicDegree = "Degree 4",
                            Age = 29,
                            ExperienceYears = 9,
                            FirstName = "FirstName4",
                            Gender = "Male",
                            SecondName = "SecondName4",
                            ThirdName = "ThirdName4"
                        },
                        new
                        {
                            Id = 5,
                            AcademicDegree = "Degree 5",
                            Age = 30,
                            ExperienceYears = 10,
                            FirstName = "FirstName5",
                            Gender = "Female",
                            SecondName = "SecondName5",
                            ThirdName = "ThirdName5"
                        },
                        new
                        {
                            Id = 6,
                            AcademicDegree = "Degree 6",
                            Age = 31,
                            ExperienceYears = 11,
                            FirstName = "FirstName6",
                            Gender = "Male",
                            SecondName = "SecondName6",
                            ThirdName = "ThirdName6"
                        },
                        new
                        {
                            Id = 7,
                            AcademicDegree = "Degree 7",
                            Age = 32,
                            ExperienceYears = 12,
                            FirstName = "FirstName7",
                            Gender = "Female",
                            SecondName = "SecondName7",
                            ThirdName = "ThirdName7"
                        },
                        new
                        {
                            Id = 8,
                            AcademicDegree = "Degree 8",
                            Age = 33,
                            ExperienceYears = 13,
                            FirstName = "FirstName8",
                            Gender = "Male",
                            SecondName = "SecondName8",
                            ThirdName = "ThirdName8"
                        },
                        new
                        {
                            Id = 9,
                            AcademicDegree = "Degree 9",
                            Age = 34,
                            ExperienceYears = 14,
                            FirstName = "FirstName9",
                            Gender = "Female",
                            SecondName = "SecondName9",
                            ThirdName = "ThirdName9"
                        },
                        new
                        {
                            Id = 10,
                            AcademicDegree = "Degree 10",
                            Age = 35,
                            ExperienceYears = 15,
                            FirstName = "FirstName10",
                            Gender = "Male",
                            SecondName = "SecondName10",
                            ThirdName = "ThirdName10"
                        },
                        new
                        {
                            Id = 11,
                            AcademicDegree = "Degree 11",
                            Age = 36,
                            ExperienceYears = 16,
                            FirstName = "FirstName11",
                            Gender = "Female",
                            SecondName = "SecondName11",
                            ThirdName = "ThirdName11"
                        },
                        new
                        {
                            Id = 12,
                            AcademicDegree = "Degree 12",
                            Age = 37,
                            ExperienceYears = 17,
                            FirstName = "FirstName12",
                            Gender = "Male",
                            SecondName = "SecondName12",
                            ThirdName = "ThirdName12"
                        },
                        new
                        {
                            Id = 13,
                            AcademicDegree = "Degree 13",
                            Age = 38,
                            ExperienceYears = 18,
                            FirstName = "FirstName13",
                            Gender = "Female",
                            SecondName = "SecondName13",
                            ThirdName = "ThirdName13"
                        },
                        new
                        {
                            Id = 14,
                            AcademicDegree = "Degree 14",
                            Age = 39,
                            ExperienceYears = 19,
                            FirstName = "FirstName14",
                            Gender = "Male",
                            SecondName = "SecondName14",
                            ThirdName = "ThirdName14"
                        },
                        new
                        {
                            Id = 15,
                            AcademicDegree = "Degree 15",
                            Age = 40,
                            ExperienceYears = 20,
                            FirstName = "FirstName15",
                            Gender = "Female",
                            SecondName = "SecondName15",
                            ThirdName = "ThirdName15"
                        },
                        new
                        {
                            Id = 16,
                            AcademicDegree = "Degree 16",
                            Age = 41,
                            ExperienceYears = 21,
                            FirstName = "FirstName16",
                            Gender = "Male",
                            SecondName = "SecondName16",
                            ThirdName = "ThirdName16"
                        },
                        new
                        {
                            Id = 17,
                            AcademicDegree = "Degree 17",
                            Age = 42,
                            ExperienceYears = 22,
                            FirstName = "FirstName17",
                            Gender = "Female",
                            SecondName = "SecondName17",
                            ThirdName = "ThirdName17"
                        },
                        new
                        {
                            Id = 18,
                            AcademicDegree = "Degree 18",
                            Age = 43,
                            ExperienceYears = 23,
                            FirstName = "FirstName18",
                            Gender = "Male",
                            SecondName = "SecondName18",
                            ThirdName = "ThirdName18"
                        },
                        new
                        {
                            Id = 19,
                            AcademicDegree = "Degree 19",
                            Age = 44,
                            ExperienceYears = 24,
                            FirstName = "FirstName19",
                            Gender = "Female",
                            SecondName = "SecondName19",
                            ThirdName = "ThirdName19"
                        },
                        new
                        {
                            Id = 20,
                            AcademicDegree = "Degree 20",
                            Age = 45,
                            ExperienceYears = 25,
                            FirstName = "FirstName20",
                            Gender = "Male",
                            SecondName = "SecondName20",
                            ThirdName = "ThirdName20"
                        },
                        new
                        {
                            Id = 21,
                            AcademicDegree = "Degree 21",
                            Age = 46,
                            ExperienceYears = 26,
                            FirstName = "FirstName21",
                            Gender = "Female",
                            SecondName = "SecondName21",
                            ThirdName = "ThirdName21"
                        },
                        new
                        {
                            Id = 22,
                            AcademicDegree = "Degree 22",
                            Age = 47,
                            ExperienceYears = 27,
                            FirstName = "FirstName22",
                            Gender = "Male",
                            SecondName = "SecondName22",
                            ThirdName = "ThirdName22"
                        },
                        new
                        {
                            Id = 23,
                            AcademicDegree = "Degree 23",
                            Age = 48,
                            ExperienceYears = 28,
                            FirstName = "FirstName23",
                            Gender = "Female",
                            SecondName = "SecondName23",
                            ThirdName = "ThirdName23"
                        },
                        new
                        {
                            Id = 24,
                            AcademicDegree = "Degree 24",
                            Age = 49,
                            ExperienceYears = 29,
                            FirstName = "FirstName24",
                            Gender = "Male",
                            SecondName = "SecondName24",
                            ThirdName = "ThirdName24"
                        },
                        new
                        {
                            Id = 25,
                            AcademicDegree = "Degree 25",
                            Age = 50,
                            ExperienceYears = 30,
                            FirstName = "FirstName25",
                            Gender = "Female",
                            SecondName = "SecondName25",
                            ThirdName = "ThirdName25"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("SoftServeTestTask.DAL.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftServeTestTask.DAL.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.HasOne("SoftServeTestTask.DAL.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftServeTestTask.DAL.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
