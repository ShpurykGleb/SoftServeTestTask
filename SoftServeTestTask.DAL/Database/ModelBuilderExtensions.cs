using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Entities.Contacts;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Database
{
    public static class ModelBuilderExtensions
    {
        private static Random? _random;
        private static IEnumerable<Student>? _students;
        private static IEnumerable<Teacher>? _teachers;

        static ModelBuilderExtensions()
        {
            _random = new Random();

        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherContacts>().HasData(GetTeacherContacts());
            modelBuilder.Entity<TeacherInfoes>().HasData(GetTeacherInfoes());

            _teachers = GetTeachers();

            modelBuilder.Entity<Teacher>().HasData(_teachers);

            modelBuilder.Entity<StudentContacts>().HasData(GetStudentContacts());
            modelBuilder.Entity<StudentInfoes>().HasData(GetStudentInfoes());

            _students = GetStudents();

            modelBuilder.Entity<Student>().HasData(_students);

            modelBuilder.Entity<Course>().HasData(GetCourses());
        }

        private static IEnumerable<StudentInfoes> GetStudentInfoes()
        {
            return Enumerable
               .Range(1, 25)
               .Select(index => new StudentInfoes()
               {
                   Id = index,
                   Age = index + 18,
                   FirstName = $"Student {index} first name",
                   SecondName = $"Student {index} second name",
                   ThirdName = $"Student {index} third name",
                   Gender = $"{index} gender",
                   BirthDate = DateTime.Now,
               });
        }

        private static IEnumerable<StudentContacts> GetStudentContacts()
        {
            return Enumerable
               .Range(1, 25)
               .Select(index => new StudentContacts()
               {
                   Id = index,
                   Email = $"student{index}@gmail.com",
                   PhoneNumber = $"+380001122334",
                   Address = $"{index} street, house {index + 1}"
               });
        }

        private static decimal GenerateRandomGPA()
        {
            double _randomValue = _random.NextDouble();
            double gpa = 3 + _randomValue * 2;
            return (decimal)gpa;
        }

        private static IEnumerable<Student> GetStudents()
        {
            return Enumerable
                .Range(1, 25)
                .Select(index => new Student()
                {
                    Id = index,
                    GPA = GenerateRandomGPA(),
                    InfoId = index,
                    ContactsId = index,
                    Group = $"{index} student group"
                });
        }

        private static IEnumerable<TeacherInfoes> GetTeacherInfoes()
        {
            return Enumerable
                .Range(1, 25)
                .Select(index => new TeacherInfoes()
                {
                    Id = index,
                    Age = index + 30,
                    FirstName = $"Teacher {index} first name",
                    SecondName = $"Teacher {index} second name",
                    ThirdName = $"Teacher {index} third name",
                    Gender = $"{index} gender",
                    BirthDate = DateTime.Now,
                });
        }

        private static IEnumerable<TeacherContacts> GetTeacherContacts()
        {
            return Enumerable
                .Range(1, 25)
                .Select(index => new TeacherContacts()
                {
                    Id = index,
                    Email = $"teacher{index}@gmail.com",
                    PhoneNumber = $"+380001122334",
                    Address = $"{index} street, house {index + 1}"
                });
        }

        private static IEnumerable<Teacher> GetTeachers()
        {
            return Enumerable
                .Range(1, 25)
                .Select(index => new Teacher()
                {
                    Id = index,
                    AcademicDegree = $"{index} degree",
                    InfoId = index,
                    ContactsId = index,
                    ExperienceYears = index * 2,
                });
        }

        private static IEnumerable<Course> GetCourses()
        {
            return Enumerable
                .Range(1, 25)
                .Select(index => new Course()
                {
                    Id = index,
                    Name = $"{index} course name",
                    Description = $"{index} course description",
                });
        }
    }
}
