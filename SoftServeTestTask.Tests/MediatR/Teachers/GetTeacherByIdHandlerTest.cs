using AutoMapper;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask.BLL.MediatR.Teachers.Handlers;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Teachers
{
    public class GetTeacherByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetTeacherByIdHandler>> _loggerMock;
        private readonly IGenericRepository<Teacher> _repositoryMock;

        public GetTeacherByIdHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TeacherProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _loggerMock = new Mock<ILogger<GetTeacherByIdHandler>>();

            _repositoryMock = TeacherRepositoryMock.GetMock();
        }

        [Fact]
        public async void GetTeacherById_IdNull()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new GetTeacherByIdQuery(null), CancellationToken.None);
            });
        }

        [Fact]
        public async void GetTeacherById_IdLessThanOne()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new GetTeacherByIdQuery(0), CancellationToken.None);
            });
        }

        [Fact]
        public async void GetTeacherById_First()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            var teacher = new Teacher()
            {
                Id = 1,
                Age = 26,
                ExperienceYears = 6,
                FirstName = $"FirstName{1}",
                SecondName = $"SecondName{1}",
                ThirdName = $"ThirdName{1}",
                Gender = "Male",
                AcademicDegree = $"Degree {1}"
            };


            // Act 
            var result = await handler.Handle(new GetTeacherByIdQuery(1), CancellationToken.None);

            // Assert
            Assert.True(teacher.FirstName == result.FirstName
                && teacher.SecondName == result.SecondName
                && teacher.ThirdName == result.ThirdName);
        }

        [Fact]
        public async void GetTeacherById_Five()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            var teacher = new Teacher()
            {
                Id = 5,
                Age = 30,
                ExperienceYears = 11,
                FirstName = $"FirstName{5}",
                SecondName = $"SecondName{5}",
                ThirdName = $"ThirdName{5}",
                Gender = "Female",
                AcademicDegree = $"Degree {5}"
            };


            // Act 
            var result = await handler.Handle(new GetTeacherByIdQuery(5), CancellationToken.None);

            // Assert
            Assert.True(teacher.FirstName == result.FirstName
                && teacher.SecondName == result.SecondName
                && teacher.ThirdName == result.ThirdName);
        }

        [Fact]
        public async void GetTeacherById_Ten()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            var teacher = new Teacher()
            {
                Id = 10,
                Age = 35,
                ExperienceYears = 16,
                FirstName = $"FirstName{10}",
                SecondName = $"SecondName{10}",
                ThirdName = $"ThirdName{10}",
                Gender = "Male",
                AcademicDegree = $"Degree {10}"
            };


            // Act 
            var result = await handler.Handle(new GetTeacherByIdQuery(10), CancellationToken.None);

            // Assert
            Assert.True(teacher.FirstName == result.FirstName
                && teacher.SecondName == result.SecondName
                && teacher.ThirdName == result.ThirdName);
        }

        [Fact]
        public async void GetTeacherById_Eleven()
        {
            // Arrange
            var handler = new GetTeacherByIdHandler(_mapper, _loggerMock.Object, _repositoryMock);

            var teacher = new Teacher()
            {
                Id = 11,
                Age = 36,
                ExperienceYears = 17,
                FirstName = $"FirstName{11}",
                SecondName = $"SecondName{11}",
                ThirdName = $"ThirdName{11}",
                Gender = "Female",
                AcademicDegree = $"Degree {11}"
            };


            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new GetTeacherByIdQuery(11), CancellationToken.None);
            });
        }
    }
}
