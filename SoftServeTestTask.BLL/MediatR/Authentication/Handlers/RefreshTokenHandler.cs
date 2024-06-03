using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.BLL.Services.Authentication;
using SoftServeTestTask.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, JwtResponseShortDto>
    {
        private readonly ILogger<RefreshTokenHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public RefreshTokenHandler(ILogger<RefreshTokenHandler> logger, UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<JwtResponseShortDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenModel = request.TokenModel;

            if (tokenModel is null)
            {
                var message = "Token model can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(tokenModel), message);
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = _jwtService.GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                var message = "Principals can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(principal), message);
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                var message = "User was not found in the system.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(principal), message);
            }
            else if (user.RefreshToken != refreshToken)
            {
                var message = "User refresh token is incorrect.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }
            else if (user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                var message = "The user's refresh token has expired.";
                _logger.LogError(message);
                throw new ArgumentException(nameof(principal), message);
            }

            var newAccessToken = _jwtService.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new JwtResponseShortDto(
                   AccessToken: new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                   RefreshToken: newRefreshToken
                   );
        }
    }
}
