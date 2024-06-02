
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SoftServeTestTask.BLL.Services.Authentication
{
    public interface IJwtService
    {
        JwtSecurityToken CreateToken(List<Claim> authClaims);
        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
