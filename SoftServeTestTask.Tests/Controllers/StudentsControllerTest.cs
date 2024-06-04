using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.WebApi.Controllers;

namespace SoftServeTestTask.Tests.Controllers
{
    public class StudentsControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly StudentsController _controller;

        public StudentsControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new StudentsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfStudents()
        {
            // Arrange
            var students = new List<StudentShortDto>
            {
                new StudentShortDto(18,"test","test","test","male","A",3,null),
                new StudentShortDto(18,"test","test","test","male","A",4,null),
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllStudentsQuery>(), default))
                         .ReturnsAsync(students);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnStudents = Assert.IsType<List<StudentShortDto>>(okResult.Value);
            Assert.Equal(2, returnStudents.Count);
        }

        [Fact]
        public async Task Get_ById_ReturnsOkResult_WithStudent()
        {
            // Arrange
            var student = new StudentShortDto(18, "test", "test", "test", "male", "A", 3, null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetStudentByIdQuery>(), default))
                         .ReturnsAsync(student);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnStudent = Assert.IsType<StudentShortDto>(okResult.Value);
            Assert.Equal("test", returnStudent.FirstName);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            var studentCreateDto = new StudentCreateDto(18, "test", "test", "test", "male", "A", 3, null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateStudentCommand>(), default))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Post(studentCreateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task Put_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            var studentWithIdDto = new StudentWithIdDto(1, 18, "test", "test", "test", "male", "A", 3, null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateStudentCommand>(), default))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Put(studentWithIdDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), default))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}

