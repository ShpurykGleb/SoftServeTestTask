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

        [Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllTeacherQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetTeacherByIdQuery(id)));
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(TeacherCreateDto teacher)
        {
            return Ok(await _mediator.Send(new CreateTeacherCommand(teacher)));
        }

        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(TeacherWithIdDto teacher)
        {
            return Ok(await _mediator.Send(new UpdateTeacherCommand(teacher)));
        }

        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteTeacherCommand(id)));
        }
    }
}
