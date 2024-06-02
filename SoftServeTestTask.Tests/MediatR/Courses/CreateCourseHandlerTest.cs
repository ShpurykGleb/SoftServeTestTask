using AutoMapper;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.BLL.MediatR.Courses.Handlers;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Courses
{
    public class CreateCourseHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Course> _courseRepositoryMock;
        private readonly IGenericRepository<Teacher> _teacherRepositoryMock;
        private readonly IGenericRepository<Student> _studentRepositoryMock;

        public CreateCourseHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CourseProfile>();
                c.AddProfile<TeacherProfile>();
                c.AddProfile<StudentProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _courseRepositoryMock = CourseRepositoryMock.GetMock();
            _teacherRepositoryMock = TeacherRepositoryMock.GetMock();
            _studentRepositoryMock = StudentRepositoryMock.GetMock();
        }

        [Fact]
        public async void CreateCourse_GoodCourse_Should_Pass()
        {
            // Arrange
            var handler = new CreateCourseHandler(_mapper, _courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            var course = new CourseCreateDto(
                Name: "Mathematics",
                Description: "Advanced Mathematics Course",
                Teachers: new List<EntityDto>() { new EntityDto(1), new EntityDto(5) },
                Students: new List<EntityDto>() { new EntityDto(8), new EntityDto(7) }
            );

            // Act 
            var result = await handler.Handle(new CreateCourseCommand(course), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void CreateCourse_NullCourse_Should_Throw_Exception()
        {
            // Arrange
            var handler = new CreateCourseHandler(_mapper, _courseRepositoryMock, _teacherRepositoryMock, _studentRepositoryMock);

            CourseCreateDto course = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new CreateCourseCommand(course), CancellationToken.None);
            });
        }
    }
}
