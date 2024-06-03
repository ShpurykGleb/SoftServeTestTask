using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Teachers
{
    public class CreateTeacherHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CreateTeacherHandler>> _loggerMock;
        private readonly IGenericRepository<Teacher> _teacherRepositoryMock;
        private readonly IGenericRepository<Course> _courseRepositoryMock;

        public CreateTeacherHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TeacherProfile>();
                c.AddProfile<CourseProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _loggerMock = new Mock<ILogger<CreateTeacherHandler>>();

            _teacherRepositoryMock = TeacherRepositoryMock.GetMock();

            _courseRepositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void CreateTeacher_GoodTeacher_Should_Pass()
        {
            // Arrange
            var handler = new CreateTeacherHandler(_mapper, _loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            var teacher = new TeacherCreateDto(
                 Age: 26,
                 ExperienceYears: 6,
                 FirstName: $"FirstName{1}",
                 SecondName: $"SecondName{1}",
                 ThirdName: $"ThirdName{1}",
                 Gender: "Male",
                 AcademicDegree: $"Degree {1}",
                 Courses: new List<EntityDto>() { new EntityDto(1), new EntityDto(2) }
            );

            // Act 
            var result = await handler.Handle(new CreateTeacherCommand(teacher), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void CreateTeacher_NullTeacher_Should_Throw_Exception()
        {
            // Arrange
            var handler = new CreateTeacherHandler(_mapper, _loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            TeacherCreateDto teacher = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new CreateTeacherCommand(teacher), CancellationToken.None);
            });
        }
    }
}
