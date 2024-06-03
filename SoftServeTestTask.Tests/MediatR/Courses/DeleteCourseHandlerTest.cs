using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.BLL.MediatR.Courses.Handlers;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Courses
{
    public class DeleteCourseHandlerTest
    {
        private readonly Mock<ILogger<DeleteCourseHandler>> _loggerMock;
        private readonly IGenericRepository<Course> _repositoryMock;

        public DeleteCourseHandlerTest()
        {
            _loggerMock = new Mock<ILogger<DeleteCourseHandler>>();
            _repositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void Delete_First_Course_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteCourseCommand(1), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Fifth_Course_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteCourseCommand(5), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Tenth_Course_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteCourseCommand(10), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Twelfth_Course_Should_Not_Be_True()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteCourseCommand(12), CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void Delete_Course_Id_Null_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new DeleteCourseCommand(null), CancellationToken.None);
            });
        }

        [Fact]
        public async void Delete_Course_Id_Less_Than_One_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteCourseHandler(_loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new DeleteCourseCommand(-1), CancellationToken.None);
            });
        }
    }
}
