using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.BLL.MediatR.Courses.Handlers;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Courses
{
    public class UpdateCourseHandlerTest
    {
        private readonly IGenericRepository<Course> _courseRepositoryMock;
        private readonly IGenericRepository<Teacher> _teacherRepositoryMock;
        private readonly IGenericRepository<Student> _studentRepositoryMock;

        public UpdateCourseHandlerTest()
        {
            _courseRepositoryMock = CourseRepositoryMock.GetMock();
            _teacherRepositoryMock = TeacherRepositoryMock.GetMock();
            _studentRepositoryMock = StudentRepositoryMock.GetMock();
        }

        [Fact]
        public async Task UpdateCourse_Course_Null_Should_Throw_ArgumentNullException()
        {
            // Arrange
            var handler = new UpdateCourseHandler(_courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            CourseUpdateDto course = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new UpdateCourseCommand(course), CancellationToken.None);
            });
        }

        [Fact]
        public async Task UpdateCourse_Course_Id_Less_Than_Zero_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateCourseHandler(_courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            var course = new CourseUpdateDto(
                Id: -1,
                Name: "Math",
                Description: "Advanced Math Course",
                Teachers: new List<EntityDto>(),
                Students: new List<EntityDto>()
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await handler.Handle(new UpdateCourseCommand(course), CancellationToken.None);
            });
        }

        [Fact]
        public async Task UpdateCourse_Course_Good_Should_Pass()
        {
            // Arrange
            var handler = new UpdateCourseHandler(_courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            var course = new CourseUpdateDto(
                Id: 1,
                Name: "Math",
                Description: "Advanced Math Course",
                Teachers: new List<EntityDto>(),
                Students: new List<EntityDto>()
            );

            // Act 
            var result = await handler.Handle(new UpdateCourseCommand(course), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateCourse_Course_Id_Not_Exist_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateCourseHandler(_courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            var course = new CourseUpdateDto(
                Id: 100,
                Name: "Math",
                Description: "Advanced Math Course",
                Teachers: new List<EntityDto>(),
                Students: new List<EntityDto>()
            );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new UpdateCourseCommand(course), CancellationToken.None);
            });
        }
    }
}
