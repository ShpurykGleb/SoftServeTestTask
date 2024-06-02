using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;

namespace SoftServeTestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModel)
        {
            return Ok(await _mediator.Send(new LoginCommand(loginModel)));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterCommand(registerModel)));
        }

        [Authorize("Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterAdminCommand(registerModel)));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModelDto tokenModel)
        {
            return Ok(await _mediator.Send(new RefreshTokenCommand(tokenModel)));
        }

        [Authorize("Admin")]
        [HttpPost("revoke/{username:alpha}")]
        public async Task<IActionResult> Revoke(string username)
        {
            return Ok(await _mediator.Send(new RevokeCommand(username)));
        }

        [Authorize("Admin")]
        [HttpPost("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            return Ok(await _mediator.Send(new RevokeAllCommand()));
        }
    }
}
