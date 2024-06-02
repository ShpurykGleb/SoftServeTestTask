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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllStudentsQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery(id)));
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(StudentCreateDto student)
        {
            return Ok(await _mediator.Send(new CreateStudentCommand(student)));
        }

        [Authorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(StudentWithIdDto student)
        {
            return Ok(await _mediator.Send(new UpdateStudentCommand(student)));
        }

        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand(id)));
        }
    }
}
