using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.BLL.Services.Authentication;
using SoftServeTestTask.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, JwtResponseDto>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public LoginHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService, IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<JwtResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var model = request.LoginModel;

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _jwtService.CreateToken(authClaims);
                var refreshToken = _jwtService.GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                await _userManager.UpdateAsync(user);

                return new JwtResponseDto(
                    Token: new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken: refreshToken,
                    Expiration: token.ValidTo
                    );
            }

            return new JwtResponseDto(
                    Token: "",
                    RefreshToken: "",
                    Expiration: DateTime.Now
                    );
        }
    }
}
