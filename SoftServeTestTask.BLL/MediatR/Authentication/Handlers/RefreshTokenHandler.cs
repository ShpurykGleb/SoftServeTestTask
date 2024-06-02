using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.BLL.Services.Authentication;
using SoftServeTestTask.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, JwtResponseShortDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public RefreshTokenHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<JwtResponseShortDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenModel = request.TokenModel;

            if (tokenModel is null)
            {
                return new JwtResponseShortDto(
                    AccessToken: "", 
                    RefreshToken: ""
                    );
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = _jwtService.GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return new JwtResponseShortDto(
                   AccessToken: "",
                   RefreshToken: ""
                   );
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return new JwtResponseShortDto(
                  AccessToken: "",
                  RefreshToken: ""
                  );
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
