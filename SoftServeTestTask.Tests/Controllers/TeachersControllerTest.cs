using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask.Tests.Controllers
{
    public class TeachersControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TeachersController _controller;

        public TeachersControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TeachersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfTeachers()
        {
            // Arrange
            var teachers = new List<TeacherShortDto>
            {
                new TeacherShortDto(18,25,"test","test","test","male","doctor",null),
                new TeacherShortDto(18,26,"test","test","test","male","doctor",null),
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllTeacherQuery>(), default))
                         .ReturnsAsync(teachers);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTeachers = Assert.IsType<List<TeacherShortDto>>(okResult.Value);
            Assert.Equal(2, returnTeachers.Count);
        }

        [Fact]
        public async Task Get_ById_ReturnsOkResult_WithTeacher()
        {
            // Arrange
            var teacher = new TeacherShortDto(18, 25, "test", "test", "test", "male", "doctor", null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTeacherByIdQuery>(), default))
                         .ReturnsAsync(teacher);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTeacher = Assert.IsType<TeacherShortDto>(okResult.Value);
            Assert.Equal("test", returnTeacher.FirstName);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            var teacherCreateDto = new TeacherCreateDto(18, 27, "test", "test", "test", "male", "doctor", null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTeacherCommand>(), default))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Post(teacherCreateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task Put_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            var teacherWithIdDto = new TeacherWithIdDto(1, 18, 26, "test", "test", "test", "male", "doctor", null);
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateTeacherCommand>(), default))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Put(teacherWithIdDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WithBoolean()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteTeacherCommand>(), default))
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
