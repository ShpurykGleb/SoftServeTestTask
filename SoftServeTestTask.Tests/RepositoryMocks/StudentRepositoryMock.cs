using Moq;
using SoftServeTestTask.DAL.Database;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using System.Linq.Expressions;

namespace SoftServeTestTask.Tests.RepositoryMocks
{
    internal class StudentRepositoryMock
    {
        private const int SIZE = 10;

        public static IGenericRepository<Student> GetMock()
        {
            List<Student> students = GenerateTestData();
            EducationalContext dbContextMock = EducationalContextMock.GetMock<Student, EducationalContext>(students, x => x.Students);

            var repositoryMock = new Mock<IGenericRepository<Student>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Student, object>>>()))
                          .ReturnsAsync(students.ToList());

            repositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<object>()))
                         .ReturnsAsync((object id) =>
                         {
                             var index = students.FindIndex(s => s.Id == (int)id);
                             if (index != -1)
                             {
                                 students.RemoveAt(index);
                                 return true;
                             }
                             return false;
                         });

            repositoryMock.Setup(repo => repo.SaveAsync())
                         .ReturnsAsync(() =>
                         {
                             try
                             {
                                 return true;
                             }
                             catch
                             {
                                 return false;
                             }
                         });

            repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<object>()))
              .ReturnsAsync((object id) =>
              {
                  var student = students.FirstOrDefault(s => s.Id == (int)id);

                  return student;
              });

            repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<object>(), It.IsAny<Expression<Func<Student, object>>[]>()))
                         .ReturnsAsync((object id, Expression<Func<Student, object>>[] includeProperties) =>
                         {
                             var student = students.FirstOrDefault(s => s.Id == (int)id);

                             return student;
                         });

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Student>()))
                         .ReturnsAsync((Student student) =>
                         {
                             students.Add(student);
                             return true;
                         });

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Student>()))
              .ReturnsAsync((Student student) =>
              {
                  var index = students.FindIndex(s => s.Id == student.Id);
                  if (index != -1)
                  {
                      students[index] = student;
                      return true;
                  }
                  return false;
              });

            return repositoryMock.Object;
        }

        private static List<Student> GenerateTestData()
        {
            var students = new List<Student>();
            for (int i = 1; i <= SIZE; i++)
            {
                students.Add(new Student
                {
                    Id = i,
                    Age = i + 18,
                    FirstName = $"FirstName{i}",
                    SecondName = $"SecondName{i}",
                    ThirdName = $"ThirdName{i}",
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    GPA = Math.Round((decimal)(3.5 + i * 0.1), 2),
                    Group = $"Group {i}"
                });
            }
            return students;
        }
    }
}
