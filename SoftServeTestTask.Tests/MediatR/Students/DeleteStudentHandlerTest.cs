using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.BLL.MediatR.Students.Handlers;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Students
{
    public class DeleteStudentHandlerTest
    {
        private readonly Mock<ILogger<DeleteStudentHandler>> _loggerMock;
        private readonly IGenericRepository<Student> _repositoryMock;

        public DeleteStudentHandlerTest()
        {
            _loggerMock = new Mock<ILogger<DeleteStudentHandler>>();
            _repositoryMock = StudentRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Delete_First_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteStudentCommand(1), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_Five_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteStudentCommand(5), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_Ten_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteStudentCommand(10), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_Twelve_Should_Not_Be_True()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteStudentCommand(12), CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Delete_Id_Null_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new DeleteStudentCommand(null), CancellationToken.None);
            });
        }

        [Fact]
        public async Task Delete_Id_Less_Than_One_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteStudentHandler(_loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new DeleteStudentCommand(-1), CancellationToken.None);
            });
        }
    }
}
