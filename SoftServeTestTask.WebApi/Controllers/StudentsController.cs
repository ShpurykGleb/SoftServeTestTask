using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.Dto.Teachers;
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
        /// <response code="200">Returns the collection of students, that were in the database.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentShortDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllStudentsQuery()));
        }

        /// <summary>
        /// Gets a student based on the entered id.
        /// </summary>
        /// <param name="id">Student id to find in database.</param>
        /// <returns>A found student.</returns>
        /// <response code="200">Returns the found student from the database.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="404">If student was not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherShortDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new student in the database.
        /// </summary>
        /// <param name="student">New student.</param>
        /// <returns>A boolean value that determines whether the student has been added to the database or not.</returns> 
        /// <response code="200">Returns a boolean value that determines whether the student has been added to the database or not.</response>
        /// <response code="400">If something is wrong with a student.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post(StudentCreateDto student)
        {
            return Ok(await _mediator.Send(new CreateStudentCommand(student)));
        }

        /// <summary>
        /// Updates an existing student in the database.
        /// </summary>
        /// <param name="student">Updated student.</param>
        /// <returns>A boolean value that determines whether the student has been updated in the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the student has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with a student.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
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
        /// <returns>A boolean value that determines whether the student has been deleted from the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the student has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
