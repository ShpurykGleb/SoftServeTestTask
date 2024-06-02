using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.BLL.MediatR.Students.Handlers;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.Tests.RepositoryMocks;

namespace SoftServeTestTask.Tests.MediatR.Students
{
    public class UpdateStudentHandlerTest
    {
        private readonly IGenericRepository<Student> _studentRepositoryMock;
        private readonly IGenericRepository<Course> _courseRepositoryMock;

        public UpdateStudentHandlerTest()
        {
            _studentRepositoryMock = StudentRepositoryMock.GetMock();
            _courseRepositoryMock = CourseRepositoryMock.GetMock();
        }

        [Fact]
        public async void UpdateStudent_Student_Null_Should_Throw_ArgumentNullException()
        {
            // Arrange
            var handler = new UpdateStudentHandler(_studentRepositoryMock, _courseRepositoryMock);

            StudentWithIdDto student = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(new UpdateStudentCommand(student), CancellationToken.None);
            });
        }

        [Fact]
        public async void UpdateStudent_Student_Id_Less_Than_Zero_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateStudentHandler(_studentRepositoryMock, _courseRepositoryMock);

            var student = new StudentWithIdDto(
                Id: -1,
                Age: 20,
                FirstName: "John",
                SecondName: "Doe",
                ThirdName: "sdfsdf",
                Gender: "Male",
                GPA: 3.5m,
                Group: "A",
                Courses: new List<EntityDto>() { }
            );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new UpdateStudentCommand(student), CancellationToken.None);
            });
        }

        [Fact]
        public async void UpdateStudent_Student_Good_Should_Pass()
        {
            // Arrange
            var handler = new UpdateStudentHandler(_studentRepositoryMock, _courseRepositoryMock);

            var student = new StudentWithIdDto(
               Id: 1,
               Age: 20,
               FirstName: "John",
               SecondName: "Doe",
               ThirdName: "sdfsdf",
               Gender: "Male",
               GPA: 3.5m,
               Group: "A",
               Courses: new List<EntityDto>() { }
           );

            // Act 
            var result = await handler.Handle(new UpdateStudentCommand(student), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void UpdateStudent_Student_Id_Not_Exist_Should_Throw_KeyNotFoundException()
        {
            // Arrange
            var handler = new UpdateStudentHandler(_studentRepositoryMock, _courseRepositoryMock);

            var student = new StudentWithIdDto(
               Id: 100,
               Age: 20,
               FirstName: "John",
               SecondName: "Doe",
               ThirdName: "sdfsdf",
               Gender: "Male",
               GPA: 3.5m,
               Group: "A",
               Courses: new List<EntityDto>() { }
           );

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await handler.Handle(new UpdateStudentCommand(student), CancellationToken.None);
            });
        }
    }
}
