using MediatR;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTeacherQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int? id)
        {
            return Ok(await _mediator.Send(new GetTeacherByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDto teacher)
        {
            return Ok(await _mediator.Send(new CreateTeacherCommand(teacher)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TeacherWithIdDto teacher)
        {
            return Ok(await _mediator.Send(new UpdateTeacherCommand(teacher)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteTeacherCommand(id)));
        }
    }
}
