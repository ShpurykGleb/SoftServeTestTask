using Moq;
using SoftServeTestTask.DAL.Database;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using System.Linq.Expressions;

namespace SoftServeTestTask.Tests.RepositoryMocks
{
    internal class TeacherRepositoryMock
    {
        private const int SIZE = 10;

        public static IGenericRepository<Teacher> GetMock()
        {
            List<Teacher> teachers = GenerateTestData();
            EducationalContext dbContextMock = EducationalContextMock.GetMock<Teacher, EducationalContext>(teachers, x => x.Teachers);

            var repositoryMock = new Mock<IGenericRepository<Teacher>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Teacher, object>>>()))
                          .ReturnsAsync(teachers.ToList());

            repositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<object>()))
                         .ReturnsAsync((object id) =>
                         {
                             var index = teachers.FindIndex(t => t.Id == (int)id);
                             if (index != -1)
                             {
                                 teachers.RemoveAt(index);

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
                   var teacher = teachers.FirstOrDefault(t => t.Id == (int)id);

                   return teacher;
               });

            repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<object>(), It.IsAny<Expression<Func<Teacher, object>>[]>()))
                         .ReturnsAsync((object id, Expression<Func<Teacher, object>>[] includeProperties) =>
                         {
                             var teacher = teachers.FirstOrDefault(t => t.Id == (int)id);

                             return teacher;
                         });

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Teacher>()))
                         .ReturnsAsync((Teacher teacher) =>
                         {
                             teachers.Add(teacher);
                             return true;
                         });

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Teacher>()))
              .ReturnsAsync((Teacher teacher) =>
              {
                  var index = teachers.FindIndex(t => t.Id == teacher.Id);
                  if (index != -1)
                  {
                      teachers[index] = teacher;
                      return true;
                  }
                  return false;
              });

            return repositoryMock.Object;
        }

        private static List<Teacher> GenerateTestData()
        {
            var teachers = new List<Teacher>();
            for (int i = 1; i <= SIZE; i++)
            {
                teachers.Add(new Teacher
                {
                    Id = i,
                    Age = i + 25,
                    ExperienceYears = i + 5,
                    FirstName = $"FirstName{i}",
                    SecondName = $"SecondName{i}",
                    ThirdName = $"ThirdName{i}",
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    AcademicDegree = $"Degree {i}"
                });
            }
            return teachers;
        }
    }
}
