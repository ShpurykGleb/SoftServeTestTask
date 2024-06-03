using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;

namespace SoftServeTestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all teachers from the database.
        /// </summary>
        /// <returns>Collection of teachers, that were in the database.</returns>
        /// <response code="200">Returns the collection of teachers, that were in the database.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeacherShortDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllTeacherQuery()));
        }

        /// <summary>
        /// Gets a teacher based on the entered id.
        /// </summary>
        /// <param name="id">Teacher id to find in database.</param>
        /// <returns>A found teacher.</returns>
        /// <response code="200">Returns the found teacher from the database.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="404">If teacher was not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherShortDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetTeacherByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new teacher in the database.
        /// </summary>
        /// <param name="teacher">New teacher.</param>
        /// <returns>A boolean value that determines whether the teacher has been added to the database or not.</returns> 
        /// <response code="200">Returns a boolean value that determines whether the teacher has been added to the database or not.</response>
        /// <response code="400">If something is wrong with a teacher.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post(TeacherCreateDto teacher)
        {
            return Ok(await _mediator.Send(new CreateTeacherCommand(teacher)));
        }

        /// <summary>
        /// Updates an existing teacher in the database.
        /// </summary>
        /// <param name="teacher">Updated teacher.</param>
        /// <returns>A boolean value that determines whether the teacher has been updated in the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the teacher has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with a teacher.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(TeacherWithIdDto teacher)
        {
            return Ok(await _mediator.Send(new UpdateTeacherCommand(teacher)));
        }

        /// <summary>
        /// Removes a teacher based on a given ID.
        /// </summary>
        /// <param name="id">Teacher id to remove from the database.</param>
        /// <returns>A boolean value that determines whether the teacher has been deleted from the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the teacher has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteTeacherCommand(id)));
        }
    }
}
