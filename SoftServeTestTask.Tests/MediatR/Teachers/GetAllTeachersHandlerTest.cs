using AutoMapper;
using SoftServeTestTask.BLL.MediatR.Teachers.Handlers;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Teachers
{
    public class GetAllTeachersHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Teacher> _repositoryMock;

        public GetAllTeachersHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TeacherProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _repositoryMock = TeacherRepositoryMock.GetMock();
        }

        [Fact]
        public async void GetAllTeachers_ReturnsAllTeachers()
        {
            // Arrange
            var handler = new GetAllTeacherHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllTeacherQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async void GetAllTeachers_NotNull()
        {
            // Arrange
            var handler = new GetAllTeacherHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllTeacherQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetAllTeachers_NotEmpty()
        {
            // Arrange
            var handler = new GetAllTeacherHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllTeacherQuery(), CancellationToken.None);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetAllTeachers_ReturnsAll_But_NotEqualSize()
        {
            // Arrange
            var handler = new GetAllTeacherHandler(_mapper, _repositoryMock);

            // Act
            var result = await handler.Handle(new GetAllTeacherQuery(), CancellationToken.None);

            // Assert
            Assert.NotEqual(3, result.Count());
        }
    }
}