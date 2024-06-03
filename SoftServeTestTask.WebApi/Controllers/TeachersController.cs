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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllTeacherQuery()));
        }

        /// <summary>
        /// Gets a teacher based on the entered id.
        /// </summary>
        /// <param name="id">Teacher id to find in database.</param>
        /// <returns>A finded teacher.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetTeacherByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new teacher in the database.
        /// </summary>
        /// <param name="teacher">New teacher.</param>
        /// <returns>Returns a boolean value that determines whether the teacher has been added to the database or not.</returns>
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(TeacherCreateDto teacher)
        {
            return Ok(await _mediator.Send(new CreateTeacherCommand(teacher)));
        }

        /// <summary>
        /// Updates an existing teacher in the database.
        /// </summary>
        /// <param name="teacher">Updated teacher.</param>
        /// <returns>Returns a boolean value that determines whether the teacher has been updated in the database or not.</returns>
        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(TeacherWithIdDto teacher)
        {
            return Ok(await _mediator.Send(new UpdateTeacherCommand(teacher)));
        }

        /// <summary>
        /// Removes a teacher based on a given ID.
        /// </summary>
        /// <param name="id">Teacher id to remove from the database.</param>
        /// <returns>Returns a boolean value that determines whether the teacher has been deleted from the database or not.</returns>
        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteTeacherCommand(id)));
        }
    }
}
