using AutoMapper;
using SoftServeTestTask.BLL.MediatR.Students.Handlers;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Students
{
    public class GetAllStudentsHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _repositoryMock;

        public GetAllStudentsHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StudentProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _repositoryMock = StudentRepositoryMock.GetMock();
        }

        [Fact]
        public async Task GetAllStudents_ReturnsAllStudents()
        {
            // Arrange
            var handler = new GetAllStudentsHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllStudentsQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async Task GetAllStudents_NotNull()
        {
            // Arrange
            var handler = new GetAllStudentsHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllStudentsQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllStudents_NotEmpty()
        {
            // Arrange
            var handler = new GetAllStudentsHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllStudentsQuery(), CancellationToken.None);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsAll_But_NotEqualSize()
        {
            // Arrange
            var handler = new GetAllStudentsHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllStudentsQuery(), CancellationToken.None);

            // Assert
            Assert.NotEqual(3, result.Count());
        }
    }
}
