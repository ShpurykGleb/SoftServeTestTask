using AutoMapper;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Profiles;
using SoftServeTestTask.BLL.MediatR.Students.Handlers;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Students
{
    public class CreateStudentHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _studentRepositoryMock;
        private readonly IGenericRepository<Course> _courseRepositoryMock;

        public CreateStudentHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StudentProfile>();
                c.AddProfile<CourseProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _studentRepositoryMock = StudentRepositoryMock.GetMock();

            _courseRepositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void CreateTeacher_GoodTeacher_Should_Pass()
        {
            // Arrange
            var handler = new CreateStudentHandler(_mapper, _studentRepositoryMock, _courseRepositoryMock);

            var student = new StudentCreateDto(
                 Age: 26,
                 FirstName: $"FirstName{1}",
                 SecondName: $"SecondName{1}",
                 ThirdName: $"ThirdName{1}",
                 Gender: "Male",
                 GPA: 3,
                 Group: "A",
                 Courses: new List<EntityDto>() { new EntityDto(1), new EntityDto(2) }
            );

            // Act 
            var result = await handler.Handle(new CreateStudentCommand(student), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void CreateStudent_NullTeacher_Should_Throw_Exception()
        {
            // Arrange
            var handler = new CreateStudentHandler(_mapper, _studentRepositoryMock, _courseRepositoryMock);

            StudentCreateDto student = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new CreateStudentCommand(student), CancellationToken.None);
            });
        }
    }
}
