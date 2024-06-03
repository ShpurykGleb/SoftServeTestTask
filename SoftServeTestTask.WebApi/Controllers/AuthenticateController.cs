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

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="loginModel">The login model containing username and password.</param>
        /// <returns>Returns an authentication token.</returns>
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModel)
        {
            return Ok(await _mediator.Send(new LoginCommand(loginModel)));
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerModel">The registration model containing user details.</param>
        /// <returns>Returns the result of the registration process.</returns>
        public async Task<IActionResult> Register([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterCommand(registerModel)));
        }

        /// <summary>
        /// Registers a new admin user.
        /// </summary>
        /// <param name="registerModel">The registration model containing user details.</param>
        /// <returns>Returns the result of the registration process.</returns>
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterAdminCommand(registerModel)));
        }

        /// <summary>
        /// Refreshes the authentication token.
        /// </summary>
        /// <param name="tokenModel">The token model containing the refresh token.</param>
        /// <returns>Returns a new authentication token.</returns>
        public async Task<IActionResult> RefreshToken([FromBody] TokenModelDto tokenModel)
        {
            return Ok(await _mediator.Send(new RefreshTokenCommand(tokenModel)));
        }

        /// <summary>
        /// Revokes a user's authentication token.
        /// </summary>
        /// <param name="username">The username of the user whose token should be revoked.</param>
        /// <returns>Returns the result of the revocation process.</returns>
        [Authorize("Admin")]
        [HttpPost("revoke/{username:alpha}")]
        public async Task<IActionResult> Revoke(string username)
        {
            return Ok(await _mediator.Send(new RevokeCommand(username)));
        }

        /// <summary>
        /// Revokes all authentication tokens.
        /// </summary>
        /// <returns>Returns the result of the revocation process.</returns>
        public async Task<IActionResult> RevokeAll()
        {
            return Ok(await _mediator.Send(new RevokeAllCommand()));
        }
    }
}
