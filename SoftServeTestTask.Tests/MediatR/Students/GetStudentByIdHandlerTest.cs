using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.BLL.MediatR.Students.Handlers;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.DAL.Repositories;
using Moq;
using AutoMapper;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.Tests.RepositoryMocks;
using Microsoft.Extensions.Logging;

namespace SoftServeTestTask.Tests.MediatR.Students
{
    public class GetStudentByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetStudentByIdHandler>> _loggerMock;
        private readonly IGenericRepository<Student> _repositoryMock;

        public GetStudentByIdHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StudentProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _loggerMock = new Mock<ILogger<GetStudentByIdHandler>>();
            _repositoryMock = StudentRepositoryMock.GetMock();
        }

        [Fact]
        public async Task GetStudentById_IdNull_ThrowsArgumentNullException()
        {
            // Arrange
            var handler = new GetStudentByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new GetStudentByIdQuery(null), CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetStudentById_IdLessThanOne_ThrowsArgumentException()
        {
            // Arrange
            var handler = new GetStudentByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new GetStudentByIdQuery(0), CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetStudentById_ExistingId_ReturnsStudent()
        {
            // Arrange
            var student = new Student
            {
                Id = 5,
                Age = 20,
                FirstName = $"FirstName{5}",
                SecondName = $"SecondName{5}",
                ThirdName = $"ThirdName{5}",
                Gender = "Female",
                GPA = 3.5m,
                Group = "A",
            };

            var handler = new GetStudentByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetStudentByIdQuery(5), CancellationToken.None);

            // Assert
            Assert.True(student.FirstName == result.FirstName
                && student.SecondName == result.SecondName
                && student.ThirdName == result.ThirdName);
        }

        [Fact]
        public async Task GetStudentById_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingId = 100;
            var handler = new GetStudentByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new GetStudentByIdQuery(nonExistingId), CancellationToken.None);
            });
        }
    }
}
