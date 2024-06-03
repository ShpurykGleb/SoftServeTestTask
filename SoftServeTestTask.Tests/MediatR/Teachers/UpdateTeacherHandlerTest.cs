using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.BLL.MediatR.Teachers.Handlers;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.Tests.RepositoryMocks;
using Moq;
using Microsoft.Extensions.Logging;

namespace SoftServeTestTask.Tests.MediatR.Teachers
{
    public class UpdateTeacherHandlerTest
    {
        private readonly Mock<ILogger<UpdateTeacherHandler>> _loggerMock;
        private readonly IGenericRepository<Teacher> _teacherRepositoryMock;
        private readonly IGenericRepository<Course> _courseRepositoryMock;

        public UpdateTeacherHandlerTest()
        {
            _loggerMock = new Mock<ILogger<UpdateTeacherHandler>>();
            _teacherRepositoryMock = TeacherRepositoryMock.GetMock();
            _courseRepositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void UpdateTeacher_Teacher_Null_Should_Throw_ArgumentNullException()
        {
            // Arrange
            var handler = new UpdateTeacherHandler(_loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            TeacherWithIdDto teacher = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new UpdateTeacherCommand(teacher), CancellationToken.None);
            });
        }

        [Fact]
        public async void UpdateTeacher_Teacher_Id_Less_Than_Zero_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateTeacherHandler(_loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            var teacher = new TeacherWithIdDto(
                Id: -1,
                Age: 35,
                FirstName: "Jane",
                SecondName: "Doe",
                ThirdName: "Smith",
                Gender: "Female",
                ExperienceYears: 25,
                AcademicDegree: "Doctor",
                Courses: new List<EntityDto>() { }
            );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new UpdateTeacherCommand(teacher), CancellationToken.None);
            });
        }

        [Fact]
        public async void UpdateTeacher_Teacher_Good_Should_Pass()
        {
            // Arrange
            var handler = new UpdateTeacherHandler(_loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            var teacher = new TeacherWithIdDto(
               Id: 1,
               Age: 35,
               FirstName: "Jane",
               SecondName: "Doe",
               ThirdName: "Smith",
               Gender: "Female",
               ExperienceYears: 25,
               AcademicDegree: "Doctor",
               Courses: new List<EntityDto>() { }
           );

            // Act 
            var result = await handler.Handle(new UpdateTeacherCommand(teacher), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void UpdateTeacher_Teacher_Id_Not_Exist_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateTeacherHandler(_loggerMock.Object, _teacherRepositoryMock, _courseRepositoryMock);

            var teacher = new TeacherWithIdDto(
               Id: 100,
               Age: 35,
               FirstName: "Jane",
               SecondName: "Doe",
               ThirdName: "Smith",
               Gender: "Female",
               ExperienceYears: 25,
               AcademicDegree: "Doctor",
               Courses: new List<EntityDto>() { }
           );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new UpdateTeacherCommand(teacher), CancellationToken.None);
            });
        }
    }
}
