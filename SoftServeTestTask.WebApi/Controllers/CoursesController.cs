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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery(id)));
        }

        [Authorize("Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteCourseCommand(id)));
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateDto course)
        {
            return Ok(await _mediator.Send(new CreateCourseCommand(course)));
        }

        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(CourseUpdateDto course)
        {
            return Ok(await _mediator.Send(new UpdateCourseCommand(course)));
        }
    }
}
