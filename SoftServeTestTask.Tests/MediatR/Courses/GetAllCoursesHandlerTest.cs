using SoftServeTestTask.BLL.MediatR.Courses.Handlers;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using AutoMapper;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Courses
{
    public class GetAllCoursesHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Course> _repositoryMock;

        public GetAllCoursesHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CourseProfile>();
                c.AddProfile<TeacherProfile>();
                c.AddProfile<StudentProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _repositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void GetAllCourses_ReturnsAllCourses()
        {
            // Arrange
            var handler = new GetAllCoursesHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllCoursesQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async void GetAllCourses_NotNull()
        {
            // Arrange
            var handler = new GetAllCoursesHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllCoursesQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAllCourses_NotEmpty()
        {
            // Arrange
            var handler = new GetAllCoursesHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllCoursesQuery(), CancellationToken.None);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetAllCourses_ReturnsAll_But_NotEqualSize()
        {
            // Arrange
            var handler = new GetAllCoursesHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllCoursesQuery(), CancellationToken.None);

            // Assert
            Assert.NotEqual(3, result.Count());
        }
    }
}
