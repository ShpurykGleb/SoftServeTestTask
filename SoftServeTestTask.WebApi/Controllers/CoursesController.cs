using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Courses;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        /// <summary>
        /// Gets a course based on the entered id.
        /// </summary>
        /// <param name="id">Course id to find in database.</param>
        /// <returns>A finded course.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery(id)));
        }

        /// <summary>
        /// Creates a new course in the database.
        /// </summary>
        /// <param name="course">New course.</param>
        /// <returns>Returns a boolean value that determines whether the course has been added to the database or not.</returns>
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateDto course)
        {
            return Ok(await _mediator.Send(new CreateCourseCommand(course)));
        }

        /// <summary>
        /// Updates an existing course in the database.
        /// </summary>
        /// <param name="course">Updated course.</param>
        /// <returns>Returns a boolean value that determines whether the course has been updated in the database or not.</returns>
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
        /// <returns>Returns a boolean value that determines whether the course has been deleted from the database or not.</returns>
        [Authorize("Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteCourseCommand(id)));
        }
    }
}
