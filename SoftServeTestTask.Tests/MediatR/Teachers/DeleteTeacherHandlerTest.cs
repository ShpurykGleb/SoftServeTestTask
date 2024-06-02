using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.BLL.MediatR.Teachers.Handlers;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Teachers
{
    public class DeleteTeacherHandlerTest
    {
        private readonly IGenericRepository<Teacher> _repositoryMock;

        public DeleteTeacherHandlerTest()
        {
            _repositoryMock = TeacherRepositoryMock.GetMock();
        }

        [Fact]
        public async void Delete_First_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteTeacherCommand(1), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Five_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteTeacherCommand(5), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Ten_Should_Be_True()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteTeacherCommand(10), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Twelve_Should_Not_Be_True()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act
            var result = await handler.Handle(new DeleteTeacherCommand(12), CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void Delete_Id_Null_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new DeleteTeacherCommand(null), CancellationToken.None);
            });
        }

        [Fact]
        public async void Delete_Id_Less_Than_One_Should_Throw_Exception()
        {
            // Arrange
            var handler = new DeleteTeacherHandler(_repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new DeleteTeacherCommand(-1), CancellationToken.None);
            });
        }
    }
}
