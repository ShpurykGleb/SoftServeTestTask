using SoftServeTestTask.BLL.MediatR.Courses.Handlers;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Profiles;
using AutoMapper;
using SoftServeTestTask.Tests.RepositoryMocks;
using Microsoft.Extensions.Logging;
using Moq;

namespace SoftServeTestTask.Tests.MediatR.Courses
{
    public class GetCourseByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetCourseByIdHandler>> _loggerMock;
        private readonly IGenericRepository<Course> _repositoryMock;

        public GetCourseByIdHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CourseProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _loggerMock = new Mock<ILogger<GetCourseByIdHandler>>();

            _repositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async Task GetCourseById_CourseExists()
        {
            // Arrange
            var handler = new GetCourseByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);
            string name = "CourseName1";

            // Act
            var result = await handler.Handle(new GetCourseByIdQuery(1), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
        }

        [Fact]
        public async Task GetCourseById_CourseDoesNotExist()
        {
            // Arrange
            var handler = new GetCourseByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);
            int nonExistingCourseId = 999;

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new GetCourseByIdQuery(nonExistingCourseId), CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetCourseById_InvalidCourseId()
        {
            // Arrange
            var handler = new GetCourseByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);
            int invalidCourseId = 0;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new GetCourseByIdQuery(invalidCourseId), CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetCourseById_NullCourseId()
        {
            // Arrange
            var handler = new GetCourseByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new GetCourseByIdQuery(null), CancellationToken.None);
            });
        }
    }
}
