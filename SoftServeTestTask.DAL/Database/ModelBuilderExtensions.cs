using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Database
{
    public static class ModelBuilderExtensions
    {
        private const int SIZE = 25;
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedTeachers();

            modelBuilder.SeedStudents();

            modelBuilder.SeedCourses();
        }

        private static void SeedTeachers(this ModelBuilder modelBuilder)
        {
            var teachers = new Teacher[SIZE];
            for (int i = 1; i <= SIZE; i++)
            {
                teachers[i - 1] = new Teacher
                {
                    Id = i,
                    Age = i + 25,
                    ExperienceYears = i + 5,
                    FirstName = $"FirstName{i}",
                    SecondName = $"SecondName{i}",
                    ThirdName = $"ThirdName{i}",
                    Gender = (i % 2 == 0) ? "Male" : "Female",
                    AcademicDegree = $"Degree {i}",
                    
                };
            }
            modelBuilder.Entity<Teacher>().HasData(teachers);
        }

        private static void SeedStudents(this ModelBuilder modelBuilder)
        {
            var students = new Student[SIZE];

            for (int i = 1; i <= SIZE; i++)
            {
                students[i - 1] = new Student
                {
                    Id = i,
                    Age = 18 + (i % 5),  // Ages between 18 and 22
                    FirstName = $"StudentFirstName{i}",
                    SecondName = $"StudentSecondName{i}",
                    ThirdName = $"StudentThirdName{i}",
                    Gender = (i % 2 == 0) ? "Male" : "Female",
                    GPA = 3.0m + (i % 2) * 0.5m,  // GPA between 3.0 and 3.5
                    Group = $"Group{i % 5 + 1}"  // Groups between 1 and 5
                };
            }

            modelBuilder.Entity<Student>().HasData(students);
        }

        private static void SeedCourses(this ModelBuilder modelBuilder)
        {
            var courses = new Course[SIZE];

            for (int i = 1; i <= 25; i++)
            {
                courses[i - 1] = new Course
                {
                    Id = i,
                    Name = $"Course {i}",
                    Description = $"Description of Course {i}",
                };
            }

            modelBuilder.Entity<Course>().HasData(courses);
        }
    }
}

