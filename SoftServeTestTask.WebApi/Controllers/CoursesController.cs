using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;

namespace SoftServeTestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all courses from the database.
        /// </summary>
        /// <returns>Collection of courses, that were in the database.</returns>
        /// <response code="200">Returns the collection of courses, that were in the database.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CourseQueryDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        /// <summary>
        /// Gets a course based on the entered id.
        /// </summary>
        /// <param name="id">Course id to find in database.</param>
        /// <returns>A finded course.</returns>
        /// <response code="200">Returns the finded course from the database.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="404">If course was not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseQueryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new course in the database.
        /// </summary>
        /// <param name="course">New course.</param>
        /// <returns>A boolean value that determines whether the course has been added to the database or not.</returns> 
        /// <response code="200">Returns a boolean value that determines whether the course has been added to the database or not.</response>
        /// <response code="400">If something is wrong with a course.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post(CourseCreateDto course)
        {
            return Ok(await _mediator.Send(new CreateCourseCommand(course)));
        }

        /// <summary>
        /// Updates an existing course in the database.
        /// </summary>
        /// <param name="course">Updated course.</param>
        /// <returns>A boolean value that determines whether the course has been updated in the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the course has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with a course.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(CourseUpdateDto course)
        {
            return Ok(await _mediator.Send(new UpdateCourseCommand(course)));
        }

        /// <summary>
        /// Removes a course based on a given ID.
        /// </summary>
        /// <param name="id">Course id to remove from the database.</param>
        /// <returns>A boolean value that determines whether the course has been deleted from the database or not.</returns>
        /// <response code="200">Returns a boolean value that determines whether the course has been updated in the database or not.</response>
        /// <response code="400">If something is wrong with id.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteCourseCommand(id)));
        }
    }
}
