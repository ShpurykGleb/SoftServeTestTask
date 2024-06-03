using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.Dto.Courses;
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
        /// <returns>A response with access and refresh token, and also with expiration time of access token.</returns>
        /// <response code="200">Returns a response with access and refresh token, and also with expiration time of access token.</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtResponseDto))]
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModel)
        {
            return Ok(await _mediator.Send(new LoginCommand(loginModel)));
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerModel">The registration model containing user details.</param>
        /// <returns>A response with the result of the registration process.</returns>
        /// <response code="200">Returns a response with the result of the registration process.</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDto))]
        public async Task<IActionResult> Register([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterCommand(registerModel)));
        }

        /// <summary>
        /// Registers a new admin user.
        /// </summary>
        /// <param name="registerModel">The registration model containing user details.</param>
        /// <returns>The result of the admin registration process.</returns>
        /// <response code="200">Returns a response with the result of the admin registration process.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost("register-admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModelDto registerModel)
        {
            return Ok(await _mediator.Send(new RegisterAdminCommand(registerModel)));
        }

        /// <summary>
        /// Refreshes the authentication token.
        /// </summary>
        /// <param name="tokenModel">The token model containing the refresh token.</param>
        /// <returns>Returns a response with access and refresh token.</returns>
        /// <response code="200">Returns a response with access and refresh token.</response>
        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(JwtResponseShortDto))]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModelDto tokenModel)
        {
            return Ok(await _mediator.Send(new RefreshTokenCommand(tokenModel)));
        }

        /// <summary>
        /// Revokes a user's authentication token.
        /// </summary>
        /// <param name="username">The username of the user whose token should be revoked.</param>
        /// <returns>A boolean value as the result of the user refresh token revocation process.</returns>
        /// <response code="200">Returns a boolean value as the result of the user refresh token revocation process.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost("revoke/{username:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Revoke(string username)
        {
            return Ok(await _mediator.Send(new RevokeCommand(username)));
        }

        /// <summary>
        /// Revokes all authentication tokens.
        /// </summary>
        /// <returns>A boolean value as the result of the revocation process.</returns>
        /// <response code="200">Returns a boolean value as the result of the all users refresh tokens revocation process.</response>
        /// <response code="401">If user is not authenticated in the system.</response>
        /// <response code="403">If user is not admin.</response>
        [Authorize("Admin")]
        [HttpPost("revoke-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RevokeAll()
        {
            return Ok(await _mediator.Send(new RevokeAllCommand()));
        }
    }
}
