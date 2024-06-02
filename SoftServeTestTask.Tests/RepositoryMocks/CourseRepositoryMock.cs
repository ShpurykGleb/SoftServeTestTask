using Moq;
using SoftServeTestTask.DAL.Database;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using System.Linq.Expressions;

namespace SoftServeTestTask.Tests.RepositoryMocks
{
    internal class CourseRepositoryMock
    {
        private const int SIZE = 10;

        public static IGenericRepository<Course> GetMock()
        {
            List<Course> courses = GenerateTestData();
            EducationalContext dbContextMock = EducationalContextMock.GetMock<Course, EducationalContext>(courses, x => x.Courses);

            var repositoryMock = new Mock<IGenericRepository<Course>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Course, object>>>()))
                          .ReturnsAsync(new List<Course>() { new Course() { Id = 1, Name = "asdfdf", Description = "asdfsdf" } });

            repositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<object>()))
                         .ReturnsAsync((object id) =>
                         {
                             var index = courses.FindIndex(c => c.Id == (int)id);
                             if (index != -1)
                             {
                                 courses.RemoveAt(index);
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
                   var course = courses.FirstOrDefault(c => c.Id == (int)id);
                   return course;
               });

            repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<object>(), It.IsAny<Expression<Func<Course, object>>[]>()))
                         .ReturnsAsync((object id, Expression<Func<Course, object>>[] includeProperties) =>
                         {
                             var course = courses.FirstOrDefault(c => c.Id == (int)id);
                             return course;
                         });

            repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Course>()))
                         .ReturnsAsync((Course course) =>
                         {
                             courses.Add(course);
                             return true;
                         });

            repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Course>()))
              .ReturnsAsync((Course course) =>
              {
                  var index = courses.FindIndex(c => c.Id == course.Id);
                  if (index != -1)
                  {
                      courses[index] = course;
                      return true;
                  }
                  return false;
              });

            return repositoryMock.Object;
        }

        private static List<Course> GenerateTestData()
        {
            var courses = new List<Course>();
            for (int i = 1; i <= SIZE; i++)
            {
                courses.Add(new Course
                {
                    Id = i,
                    Name = $"CourseName{i}",
                    Description = $"CourseDescription{i}",
                    Teachers = new List<Teacher>() { },
                    Students = new List<Student>() { },
                });
            }
            return courses;
        }
    }
}
