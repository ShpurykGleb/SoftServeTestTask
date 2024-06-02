using MediatR;
using SoftServeTestTask.BLL.Dto.Authentication;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Commands
{
    public record LoginCommand(LoginModelDto LoginModel) : IRequest<JwtResponseDto>;
}
