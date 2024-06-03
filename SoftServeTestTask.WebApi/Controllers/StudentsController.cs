using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.BLL.MediatR.Students.Queries;

namespace SoftServeTestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all students from the database.
        /// </summary>
        /// <returns>Collection of students, that were in the database.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllStudentsQuery()));
        }

        /// <summary>
        /// Gets a student based on the entered id.
        /// </summary>
        /// <param name="id">Student id to find in database.</param>
        /// <returns>A finded student.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new student in the database.
        /// </summary>
        /// <param name="student">New student.</param>
        /// <returns>Returns a boolean value that determines whether the student has been added to the database or not.</returns>
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(StudentCreateDto student)
        {
            return Ok(await _mediator.Send(new CreateStudentCommand(student)));
        }

        /// <summary>
        /// Updates an existing student in the database.
        /// </summary>
        /// <param name="student">Updated student.</param>
        /// <returns>Returns a boolean value that determines whether the student has been updated in the database or not.</returns>
        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(StudentWithIdDto student)
        {
            return Ok(await _mediator.Send(new UpdateStudentCommand(student)));
        }

        /// <summary>
        /// Removes a student based on a given ID.
        /// </summary>
        /// <param name="id">Student id to remove from the database.</param>
        /// <returns>Returns a boolean value that determines whether the student has been deleted from the database or not.</returns>
        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
